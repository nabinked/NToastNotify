import { NToastNotify, ToastMessage } from '../NToastNotify'
import { Options as ToastrJsOptions } from './ToastrOptions'

class NToastNotifyToastr extends NToastNotify {
    showMessage({ message, options }: ToastMessage): void {
        const { title, ...restOptions } = options as ToastrJsOptions;
        if (toastr) {
            const displayMethod = toastr[options.type.toLowerCase() as ToastrType];
            if (displayMethod)
                displayMethod(message, title, restOptions);
            else
                console.warn('Invalid type: ' + options.type.toLowerCase())
        }
    }
    overrideLibDefaults(): void {
        if (this.options.libraryDetails.options && toastr) {
            toastr.options = this.options.libraryDetails.options;
        }
    }


}

export const nToastNotify = new NToastNotifyToastr();
