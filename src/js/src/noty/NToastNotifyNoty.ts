import { NToastNotify, ToastMessage, LibraryDetails } from './../NToastNotify'
export class NToastNotifyNoty extends NToastNotify {
    show(message: ToastMessage): void {
        const notyOpts = message.options as Noty.Options;
        notyOpts.text = message.message;
        new Noty(notyOpts).show();
    }
    overrideLibDefaults(): void {
        if (this.options.globalLibOptions) {
            Noty.overrideDefaults(this.options.globalLibOptions);
        }
    }


}