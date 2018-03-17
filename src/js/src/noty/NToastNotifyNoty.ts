import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'
export class NToastNotifyNoty extends NToastNotify {
    show(message: ToastMessage): void {
        new Noty(message.toastOptions);
    }
    overrideLibDefaults(): void {
        (window as any).Noty.overrideDefaults(this.options.globalLibOptions);
    }


}