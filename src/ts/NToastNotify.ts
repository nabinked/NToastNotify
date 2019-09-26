import './polyfills'
import * as Noty from 'noty';
import { Options as TostrJsOptions } from './toastr/ToastrOptions'
// ReSharper disable once InconsistentNaming
interface Options {
    firstLoadEvent: string;
    messages: Array<ToastMessage>;
    responseHeaderKey: string;
    requestHeaderKey: string;
    libraryDetails: LibraryDetails;
    disableAjaxToasts: boolean;
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
    options: Options = null;
    fetchHeaderValue = 'Fetch';
    init(options: Options) {
        this.options = Object.assign({}, NToastNotify.defaults, options);
        if (!this.options.disableAjaxToasts) {
            this.interceptXmlRequest();
            this.interceptNativeFetch();
        }
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
                    reject(e);
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
                    reject(e);
                };
                document.head.appendChild(link);
            } else {
                resolve();
            }
        });
    }
    handleEvents() {
        document && document.addEventListener(this.options.firstLoadEvent, this.domContentLoadedHandler.bind(this));
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
    getMessagesFromFetchResponse(response: Response) {
        const messageStr = response.headers.get(this.options.responseHeaderKey);
        if (messageStr) {
            return JSON.parse(this.urlDecode(messageStr));
        } else {
            return null;
        }
    }

    interceptXmlRequest() {
        var self = this;
        // store the native send()
        var oldSend: (data: any) => void = XMLHttpRequest.prototype.send;
        // override the native send()
        XMLHttpRequest.prototype.send = function (this: XMLHttpRequest) {
            this.addEventListener('load', self.xmlRequestOnLoadHandler.bind(self, this));
            // call the native send()
            oldSend.apply(this, arguments);
        };
    }
    xmlRequestOnLoadHandler(xmlHttpRequest: XMLHttpRequest) {
        const messages = this.getMessagesFromXmlResponse(xmlHttpRequest);
        this.showMessages(messages);
    }
    getMessagesFromXmlResponse(xmlHttpRequest: XMLHttpRequest) {
        const allResponseHeaders = xmlHttpRequest.getAllResponseHeaders();
        if (allResponseHeaders.indexOf(this.options.responseHeaderKey) > -1) {
            const messagesStr = xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey);
            if (messagesStr) {
                return JSON.parse(this.urlDecode(messagesStr));
            }
        }
        return null;
    }
    async domContentLoadedHandler() {
        await this.ensureLibExists();
        this.overrideLibDefaults();
        this.showMessages(this.options.messages);
    }
    showMessages(messages: ToastMessage[]) {
        if (messages && messages.length) {
            messages.forEach((message) => {
                this.showMessage(message);
            });
        }
    }
    urlDecode(value: string) {
        return decodeURIComponent(value.replace(/\+/g, ' '));
    }
    abstract showMessage(message: ToastMessage): void;
    abstract overrideLibDefaults(): void;

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