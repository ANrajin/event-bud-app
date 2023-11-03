import { InjectionToken } from '@angular/core';
import { Notyf } from 'notyf';

export const NOTYF = new InjectionToken<Notyf>('NotyfToken');

export function notyfFactory(): Notyf {
    return new Notyf({
        ripple: false,
        position: { x: 'center', y: 'bottom' },
        duration: 5000,
        dismissible: true,
    });
}
