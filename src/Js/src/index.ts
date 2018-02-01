import './polyfills';

interface NToastNotify {
    init(options: NToastNotifyOptions): void;
    options: NToastNotifyOptions;
    defaults: NToastNotifyOptions;
    handleEvents(): void;
    interceptXmlRequest(): void;
    xmlRequestOnLoadHandler(xmlHttpRequest: XMLHttpRequest): void;
    domContentLoadedHandler(): void;
    showToasts(messages: ToastMessage[]): void;
    showToast(message: ToastMessage): void;
}

interface NToastNotifyOptions {
    firstLoadEvent: string;
    globalToastMessageOptions: ToastrOptions;
    messages: ToastMessage[];
    responseHeaderKey: string;
}
interface ToastMessage {
    toastType: ToastrType;
    message: string;
    title: string;
    toastOptions: ToastrOptions;
}
let nToastNotify: NToastNotify = {
    options: null,
    init(options) {
        this.options = Object.assign({}, this.defaults, options);
        this.handleEvents();
        this.interceptXmlRequest();
    },
    handleEvents() {
        document && document.addEventListener('DOMContentLoaded', this.domContentLoadedHandler.bind(this));
    },
    interceptXmlRequest() {
        var self = this;
        // store the native send()
        var oldSend: (data: any) => void = XMLHttpRequest.prototype.send;
        // override the native send()
        XMLHttpRequest.prototype.send = function () {
            // process the callback queue
            this.onload = self.xmlRequestOnLoadHandler.bind(self, this);
            // call the native send()
            oldSend.apply(this, arguments);
        }
    },
    xmlRequestOnLoadHandler(xmlHttpRequest) {
        var messages = JSON.parse(xmlHttpRequest.getResponseHeader(this.options.responseHeaderKey));
        this.showToasts(messages);
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
                this.showToast(message);
            });
        }
    },
    showToast(message) {
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
        responseHeaderKey: 'NToastNotify-Messages'
    }
}

export default nToastNotify;