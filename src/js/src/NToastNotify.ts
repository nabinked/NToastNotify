import './polyfills'
import * as Noty from 'noty';
import { Options as TostrJsOptions } from './toastr/ToastrOptions'
// ReSharper disable once InconsistentNaming
interface InitOptions {
    firstLoadEvent: string;
    messages: Array<ToastMessage>;
    responseHeaderKey: string;
    requestHeaderKey: string;
    libraryDetails: LibraryDetails;
}

export type LibraryDetails = {
    varName: string,
    scriptSrc: string,
    styleHref: string;
    options: TostrJsOptions | Noty.Options; // global options for the library
}

export type ToastMessage = {
    message: string;
    options: TostrJsOptions | Noty.Options;
}

export abstract class NToastNotify {
    options: InitOptions = null;
    fetchHeaderValue = 'Fetch';
    init(options: InitOptions) {
        this.options = Object.assign({}, NToastNotify.defaults, options);
        this.interceptXmlRequest();
        this.interceptNativeFetch();
        this.handleEvents();
    }
    ensureLibExists() {
        if (this.libPresentAlready()) {
            return true;
        } else {
            return this.loadLibAsync();
        }
    }
    libPresentAlready() {
        return typeof (window as any)[this.options.libraryDetails.varName] !== 'undefined';
    }
    loadLibAsync() {
        return Promise.all([this.loadStyleAsync(), this.loadScriptAsync()]);
    }

    loadScriptAsync() {
        return new Promise((resolve, reject) => {
            if (this.options.libraryDetails.scriptSrc) {
                const script = document.createElement('script');
                script.setAttribute('src', this.options.libraryDetails.scriptSrc);
                script.onload = () => {
                    resolve();
                };
                script.onerror = (e) => {
                    reject(e.message);
                };
                document.head.appendChild(script);
            } else {
                resolve();
            }
        });
    }
    loadStyleAsync() {
        return new Promise((resolve, reject) => {
            if (this.options.libraryDetails.scriptSrc) {
                const link = document.createElement('link');
                link.setAttribute('rel', 'stylesheet');
                link.type = 'text/css';
                link.href = this.options.libraryDetails.styleHref;
                link.onload = () => {
                    resolve();
                };
                link.onerror = (e) => {
                    reject(e.message);
                };
                document.head.appendChild(link);
            } else {
                resolve();
            }
        });
    }
    handleEvents() {
        document && document.addEventListener('DOMContentLoaded', this.domContentLoadedHandler.bind(this));
    }
    getResponseHeaderKey() {
        return this.options.responseHeaderKey;
    }
    interceptNativeFetch() {
        const self = this;
        const oldFetch = window.fetch;
        if (oldFetch) {
            window.fetch = function (this: XMLHttpRequest) {
                const requestInfo = arguments[0] as RequestInfo;
                self.prepareRequestInfo(requestInfo);

                const init = arguments.length > 1 ? arguments[1] as RequestInit : {} as RequestInit;
                self.prepareReuqestInit(init);

                return oldFetch.apply(this, [requestInfo, init]);
            };
        }
    }
    prepareRequestInfo(request: RequestInfo) {
        if (request instanceof Request) {
            request.headers.append(this.options.requestHeaderKey, this.fetchHeaderValue);
        }
    }
    prepareReuqestInit(reqInit: RequestInit) {
        if (reqInit) {
            //if headers is not defined yet. define one
            if (!reqInit.headers) {
                const newHeaders = new Headers();
                newHeaders.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                reqInit.headers = newHeaders;
            } else {
                if (reqInit.headers instanceof Headers) {
                    reqInit.headers.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                } else if (reqInit.headers instanceof Object) {
                    (reqInit.headers as any)[this.options.requestHeaderKey] = this.fetchHeaderValue;
                } else {
                    console.warn('NToastNotify header not set. Toast notification will not work');
                }
            }
        }
    }
    interceptXmlRequest() {
        var self = this;
        // store the native send()
        var oldSend: (data: any) => void = XMLHttpRequest.prototype.send;
        // override the native send()
        XMLHttpRequest.prototype.send = function (this: XMLHttpRequest) {
            this.setRequestHeader(self.options.requestHeaderKey, 'XMLHttpRequest');
            this.addEventListener('load', self.xmlRequestOnLoadHandler.bind(self, this));
            // call the native send()
            oldSend.apply(this, arguments);
        };
    }
    xmlRequestOnLoadHandler(xmlHttpRequest: XMLHttpRequest) {
        const messages = this.xmlGetMessagesFromResponse(xmlHttpRequest);
        this.showMessages(messages);
    }
    xmlGetMessagesFromResponse(xmlHttpRequest: XMLHttpRequest) {
        const messagesStr = xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey);
        if (messagesStr) {
            return JSON.parse(messagesStr);
        }
        return null;
    }
    getMessagesFromFetchResponse(response: Response) {
        const messageStr = response.headers.get(this.options.responseHeaderKey);
        if (messageStr) {
            return JSON.parse(messageStr);
        } else {
            return null;
        }
    }
    async domContentLoadedHandler() {
        await this.ensureLibExists();
        this.overrideLibDefaults();
        this.showMessages(this.options.messages);
    }
    abstract overrideLibDefaults(): void;
    showMessages(messages: ToastMessage[]) {
        if (messages && messages.length) {
            messages.forEach((message) => {
                this.showMessage(message);
            });
        }
    }
    abstract showMessage(message: ToastMessage): void;

    static defaults: {
        firstLoadEvent: 'DOMContentLoaded',
        globalToastrOptions: {},
        messages: null,
        responseHeaderKey: null,
        requestHeaderKey: null,
        libCdnScript: null,
        // ReSharper disable once StatementTermination
        libCdnStyleUrl: null
    };
}