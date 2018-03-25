import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'
import { Options as ToastrJsOptions } from './ToastrOptions'

export class NToastNotifyToastr extends NToastNotify {

    show(message: ToastMessage): void {
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
        if (this.options.globalLibOptions && toastr) {
            toastr.options = this.options.globalLibOptions
        }
    }


}