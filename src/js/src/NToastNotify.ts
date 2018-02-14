import './polyfills'

interface InitOptions {
    firstLoadEvent: string;
    globalLibOptions: ToastrOptions;
    messages: Array<ToastMessage>;
    responseHeaderKey: string;
    requestHeaderKey: string;
    libraryDetails: LibraryDetails
}

export interface LibraryDetails {
    varName: string,
    scriptSrc: string,
    styleHref: string
}
export interface ToastMessage {
    toastType: ToastrType;
    message: string;
    title: string;
    toastOptions: ToastrOptions;
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
            return;
        } else {
            return this.loadLibAsync();
        }
    }
    libPresentAlready() {
        return typeof (window as any)[this.options.libraryDetails.varName] !== 'undefined';
    }
    loadLibAsync() {
        return Promise.all([this.loadStyleAsync(), this.loadScriptAsync()])
    }

    loadScriptAsync() {
        return new Promise((resolve, reject) => {
            if (this.options.libraryDetails.scriptSrc) {
                const script = document.createElement('script');
                script.setAttribute('src', this.options.libraryDetails.scriptSrc);
                script.onload = (e) => {
                    resolve();
                };
                script.onerror = (e) => {
                    reject(e.message)
                }
                document.head.appendChild(script);
            } else {
                resolve()
            }
        })
    }
    loadStyleAsync() {
        return new Promise((resolve, reject) => {
            if (this.options.libraryDetails.scriptSrc) {
                const link = document.createElement('link');
                link.setAttribute('rel', 'stylesheet');
                link.type = 'text/css'
                link.href = this.options.libraryDetails.styleHref;
                link.onload = (e) => {
                    resolve();
                };
                link.onerror = (e) => {
                    reject(e.message);
                }
                document.head.appendChild(link);
            } else {
                resolve();
            }
        })
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
            window.fetch = function () {
                const requestInfo = arguments[0] as RequestInfo;
                self.prepareRequestInfo(requestInfo);

                const init = arguments.length > 1 ? arguments[1] as RequestInit : {} as RequestInit;
                self.prepareReuqestInit(init);

                return oldFetch.apply(this, [requestInfo, init]);
            }
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
        XMLHttpRequest.prototype.send = function () {
            this.setRequestHeader(self.options.requestHeaderKey, 'XMLHttpRequest');

            // process the callback queue
            this.onload = self.xmlRequestOnLoadHandler.bind(self, this);
            // call the native send()
            oldSend.apply(this, arguments);
        }
    }
    xmlRequestOnLoadHandler(xmlHttpRequest: XMLHttpRequest) {
        const messages = this.xmlGetMessagesFromResponse(xmlHttpRequest);
        this.showToasts(messages);
    }
    xmlGetMessagesFromResponse(xmlHttpRequest: XMLHttpRequest) {
        const messagesStr = xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey);
        if (messagesStr) {
            return JSON.parse(messagesStr);
        }
        return null;
    }
    fetchGetMessagesFromResponse(response: Response) {
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
        this.showToasts(this.options.messages);
    }
    abstract overrideLibDefaults(): void;
    showToasts(messages: ToastMessage[]) {
        if (messages && messages.length) {
            messages.forEach((message, index, array) => {
                this.show(message);
            });
        }
    }
    abstract show(message: ToastMessage): void;

    static defaults: {
        firstLoadEvent: 'DOMContentLoaded',
        globalToastrOptions: {},
        messages: null,
        responseHeaderKey: null,
        requestHeaderKey: null,
        libCdnScript: null,
        libCdnStyleUrl: null
    }
}