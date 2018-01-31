import './polyfills';


interface NToastNotify {
    init(options: NToastNotifyOptions): void;
    options: NToastNotifyOptions;
    defaults: NToastNotifyOptions;
    handleEvents(): void;
    addXmlRequestCallback(callback: Function): void;
    domContentLoadedHandler(): void;
}

interface NToastNotifyOptions {
    firstLoadEvent: string;
    globalToastMessageOptions: ToastrOptions;
    messages: ToastMessage[];
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
    },
    handleEvents() {
        document && document.addEventListener('DOMContentLoaded', this.domContentLoadedHandler.bind(this));
    },
    addXmlRequestCallback(callback) {
        var oldSend: (data: any) => void;
        var i: number;
        if ((XMLHttpRequest as any).callbacks) {
            // we've already overridden send() so just add the callback
            (XMLHttpRequest as any).callbacks.push(callback);
        } else {
            // create a callback queue
            (XMLHttpRequest as any).callbacks = [callback];
            // store the native send()
            oldSend = XMLHttpRequest.prototype.send;
            // override the native send()
            XMLHttpRequest.prototype.open = function () {
                // process the callback queue
                for (i = 0; i < (XMLHttpRequest as any).callbacks.length; i++) {
                    (XMLHttpRequest as any).callbacks[i](this);
                }
                // call the native send()
                oldSend.apply(this, arguments);
            }
        }
    },
    domContentLoadedHandler() {
        if (toastr) {
            toastr.options = this.options.globalToastMessageOptions;
            if (this.options.messages && this.options.messages.length) {
                this.options.messages.forEach((message, index, array) => {
                    toastr[message.toastType](message.message, message.title, message.toastOptions);
                });
            }
        }
    },
    defaults: {
        firstLoadEvent: 'DOMContentLoaded',
        globalToastMessageOptions: <ToastrOptions>null,
        messages: []
    }
}