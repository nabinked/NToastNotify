import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'

export class NToastNotifyNoty extends NToastNotify {
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