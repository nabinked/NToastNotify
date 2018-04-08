import { NToastNotify, ToastMessage } from './../NToastNotify'
import { Options as ToastrJsOptions } from './ToastrOptions'

class NToastNotifyToastr extends NToastNotify {
    showMessage(message: ToastMessage): void {
        const args: any[] = [];
        const options = message.options as ToastrJsOptions;

        args.push(message.message);
        args.push(options.title);
        if (message.options) {
            args.push(message.options);
        }
        if (toastr) {
            toastr[options.type.toLowerCase()](...args);
        }
    }
    overrideLibDefaults(): void {
        if (this.options.libraryDetails.options && toastr) {
            toastr.options = this.options.libraryDetails.options;
        }
    }


}

export const nToastNotify = new NToastNotifyToastr();
