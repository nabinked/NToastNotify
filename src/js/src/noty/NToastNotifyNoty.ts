import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'
export class NToastNotifyNoty extends NToastNotify {
    show(message: ToastMessage): void {
        const notyOpts = <Noty.Options>message.toastOptions;
        notyOpts.text = message.message;
        new Noty(message.toastOptions).show();
    }
    overrideLibDefaults(): void {
        (window as any).Noty.overrideDefaults(this.options.globalLibOptions);
    }


}