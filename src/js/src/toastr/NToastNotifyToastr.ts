import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'

export class NToastNotifyToastr extends NToastNotify {

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