import { NToastNotify, ToastMessage } from '../NToastNotify'

class NToastNotifyNoty extends NToastNotify {
    showMessage(message: ToastMessage): void {
        const notyOpts = message.options as Noty.Options;
        notyOpts.text = message.message;
        new Noty(notyOpts).show();
    }
    overrideLibDefaults(): void {
        if (this.options.libraryDetails.options && Noty) {
            Noty.overrideDefaults(this.options.libraryDetails.options);
        }
    }
}
export const nToastNotify = new NToastNotifyNoty();
