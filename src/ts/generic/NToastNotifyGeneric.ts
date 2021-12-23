import { NToastNotify, ToastMessage } from '../NToastNotify'

declare function genericToastNotify(message: string, options: any): void;

class NToastNotifyGeneric extends NToastNotify {
    showMessage({ message, options }: ToastMessage): void {
        genericToastNotify(message, options);
    }
    overrideLibDefaults(): void {
    }
}

export const nToastNotify = new NToastNotifyGeneric();