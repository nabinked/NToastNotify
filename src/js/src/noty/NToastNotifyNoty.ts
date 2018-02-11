import { NToastNotify, ToastMessage, LibOptions } from './../NToastNotify'

let libOptions: LibOptions = {
    scriptSrc: 'https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js',
    varName: 'toastr',
    styleHref: ''

}
export class NToastNotifyNoty extends NToastNotify {
    constructor(options?: LibOptions) {
        super(options || libOptions);
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

}