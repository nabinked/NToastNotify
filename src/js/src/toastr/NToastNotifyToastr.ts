import { NToastNotify, ToastMessage, NToastNotifyOptions } from './../NToastNotify'

let ntoastNotifyOptions: NToastNotifyOptions = {
    libScriptSrc: 'https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js',
    libVarName: 'toastr',
    libStyleHref: 'https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css'

}
export class NToastNotifyToastr extends NToastNotify {
    constructor(options?: NToastNotifyOptions) {
        super(options || ntoastNotifyOptions);
    }
    show(message: ToastMessage): void {
        const args: any[] = [];
        args.push(message.message);
        args.push(message.title);
        if (message.toastOptions) {
            args.push(message.toastOptions);
        }
        if (toastr) {
            toastr[message.toastType.toLowerCase()](...args);
        }
    }
    overrideLibDefaults(): void {
        toastr.options = this.options.globalLibOptions
    }


}