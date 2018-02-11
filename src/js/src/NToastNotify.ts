import './polyfills'
interface NToastNotifyOptions {
    firstLoadEvent: string;
    globalToastrOptions: ToastrOptions;
    messages: ToastMessage[];
    responseHeaderKey: string;
    requestHeaderKey: string;
    libScriptSrc: string,
    libStyleHref: string
}

export interface ToastMessage {
    toastType: ToastrType;
    message: string;
    title: string;
    toastOptions: ToastrOptions;
}

export interface LibOptions {
    varName: string,
    scriptSrc: string,
    styleHref: string
}

export abstract class NToastNotify {
    libOptions: LibOptions;
    constructor(options: LibOptions) {
        this.libOptions = options;
    }
    options: NToastNotifyOptions = null;
    fetchHeaderValue = 'Fetch';
    async init(options: NToastNotifyOptions) {
        this.options = Object.assign({}, NToastNotify.defaults, options);
        this.interceptXmlRequest();
        this.interceptNativeFetch();
        if (this.libPresentAlready()) {
            this.showToasts(this.options.messages)
        } else {
            await this.loadLibAsync();
            this.showToasts(this.options.messages)
        }

    }
    libPresentAlready() {
        return typeof (window as any)[this.libOptions.varName] !== 'undefined';
    }
    loadLibAsync() {
        return Promise.all([this.loadStyleAsync(), this.loadScriptAsync()])
    }
    getScriptTagSrc() {
        return this.options.libScriptSrc || this.libOptions.scriptSrc;
    }
    getStyleTagHref() {
        return this.options.libStyleHref || this.libOptions.styleHref;
    }
    loadScriptAsync() {
        return new Promise((resolve, reject) => {
            if (this.getScriptTagSrc()) {
                const script = document.createElement('script');
                script.setAttribute('src', this.getScriptTagSrc());
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
            if (this.getStyleTagHref()) {
                const link = document.createElement('link');
                link.setAttribute('rel', 'stylesheet');
                link.type = 'text/css'
                link.href = this.getStyleTagHref()
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
    domContentLoadedHandler() {
        if (toastr) {
            toastr.options = this.options.globalToastrOptions;
            this.showToasts(this.options.messages);
        }
    }
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
        messages: [],
        responseHeaderKey: null,
        requestHeaderKey: null,
        libCdnScript: null,
        libCdnStyleUrl: null
    }
}