import './polyfills';

interface NToastNotify {
    fetchHeaderValue: string;
    init(options: NToastNotifyOptions): void;
    options: NToastNotifyOptions;
    defaults: NToastNotifyOptions;
    handleEvents(): void;
    getResponseHeaderKey(): string;
    interceptXmlRequest(): void;
    xmlGetMessagesFromResponse(xmlHttpRequest: XMLHttpRequest): ToastMessage[];
    fetchGetMessagesFromResponse(response: Response): string;
    xmlRequestOnLoadHandler(xmlHttpRequest: XMLHttpRequest): void;
    domContentLoadedHandler(): void;
    showToasts(messages: ToastMessage[]): void;
    show(message: ToastMessage): void;
    interceptNativeFetch(): void;
    prepareReuqestInit(init: RequestInit): void;
    prepareRequestInfo(input: RequestInfo): any;
}

interface NToastNotifyOptions {
    firstLoadEvent: string;
    globalToastMessageOptions: ToastrOptions;
    messages: ToastMessage[];
    responseHeaderKey: string;
    requestHeaderKey: string;
}
interface ToastMessage {
    toastType: ToastrType;
    message: string;
    title: string;
    toastOptions: ToastrOptions;
}
let libToastr: NToastNotify = {
    options: null,
    fetchHeaderValue: 'Fetch',
    init(options) {
        this.options = Object.assign({}, this.defaults, options);
        this.handleEvents();
        this.interceptXmlRequest();
        this.interceptNativeFetch();
    },
    handleEvents() {
        document && document.addEventListener(this.options.firstLoadEvent, this.domContentLoadedHandler.bind(this));
    },
    getResponseHeaderKey() {
        return this.options.responseHeaderKey;
    },
    interceptNativeFetch() {
        const self = this;
        const oldFetch = window.fetch;
        if (oldFetch) {
            window.fetch = function () {
                const input = arguments[0] as RequestInfo;
                self.prepareRequestInfo(input);

                const init = arguments.length > 1 ? arguments[1] as RequestInit : {} as RequestInit;
                self.prepareReuqestInit(init);

                return oldFetch.apply(this, [input, init]);
            }
        }
    },
    prepareRequestInfo(input) {
        if (input instanceof Request) {
            input.headers.append(this.options.requestHeaderKey, this.fetchHeaderValue);
        }
    },
    prepareReuqestInit(init) {
        if (init) {
            //if headers is not defined yet. define one
            if (!init.headers) {
                const newHeaders = new Headers();
                newHeaders.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                init.headers = newHeaders;
            } else {
                if (init.headers instanceof Headers) {
                    init.headers.set(this.options.requestHeaderKey, this.fetchHeaderValue);
                } else if (init.headers instanceof Object) {
                    (init.headers as any)[this.options.requestHeaderKey] = this.fetchHeaderValue;
                } else {
                    console.warn('NToastNotify header not set. Toast notification will not work');
                }
            }
        }


    },
    interceptXmlRequest() {
        const self = this;
        // store the native send() and onLoad()
        const oldSend: (data: any) => void = XMLHttpRequest.prototype.send;
        const oldOnLoad: (data: any) => void = XMLHttpRequest.prototype.onload;
        // override the native send()
        XMLHttpRequest.prototype.send = function () {
            this.setRequestHeader(self.options.requestHeaderKey, 'XMLHttpRequest');
            // process the callback queue
            this.onload = function () {
                self.xmlRequestOnLoadHandler.bind(self, this);
                //call the old onLoad
                oldOnLoad.apply(this, arguments);
            }
            // call the native send()
            oldSend.apply(this, arguments);
        }
    },
    xmlRequestOnLoadHandler(xmlHttpRequest) {
        const messages = this.xmlGetMessagesFromResponse(xmlHttpRequest);
        this.showToasts(messages);
    },
    xmlGetMessagesFromResponse(xmlHttpRequest) {
        const messagesStr = xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey);
        if (messagesStr) {
            return JSON.parse(messagesStr);
        }
        return null;
    },
    fetchGetMessagesFromResponse(response) {
        const messageStr = response.headers.get(this.options.responseHeaderKey);
        if (messageStr) {
            return JSON.parse(messageStr);
        } else {
            return null;
        }
    },
    domContentLoadedHandler() {
        if (toastr) {
            toastr.options = this.options.globalToastMessageOptions;
            this.showToasts(this.options.messages);
        }
    },
    showToasts(messages) {
        if (messages && messages.length) {
            messages.forEach((message, index, array) => {
                this.show(message);
            });
        }
    },
    show(message) {
        const args: any[] = [];
        args.push(message.message);
        args.push(message.title);
        if (message.toastOptions) {
            args.push(message.toastOptions);
        }
        toastr[message.toastType.toLowerCase()](...args);

    },
    defaults: {
        firstLoadEvent: 'DOMContentLoaded',
        globalToastMessageOptions: <ToastrOptions>null,
        messages: [],
        responseHeaderKey: 'NToastNotify-Messages',
        requestHeaderKey: 'NToastNotify-Request-Type',
    }
}

export { libToastr as toastr }