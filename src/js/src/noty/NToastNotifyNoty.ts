import { NToastNotify, ToastMessage, NToastNotifyOptions } from './../NToastNotify'

let ntoastNotifyOptions: NToastNotifyOptions = {
    libScriptSrc: 'https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.js',
    libVarName: 'toastr',
    libStyleHref: 'https://cdnjs.cloudflare.com/ajax/libs/noty/3.1.4/noty.min.css'

}
export class NToastNotifyNoty extends NToastNotify {
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
        (window as any).Noty.overrideDefaults(this.options.globalLibOptions);
    }


}