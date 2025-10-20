import { Injectable } from '@angular/core';

export interface Toast {
  id: number;
  message: string;
  type: string;
}

@Injectable({ providedIn: 'root' })
export class ToastService {
  private nextId = 0;
  toasts: Toast[] = [];

  show(message: string, type: string = 'info', duration: number = 11000) {
    const toast: Toast = { id: this.nextId++, message, type };
    this.toasts.push(toast);

    // Auto-remove after duration
    setTimeout(() => this.remove(toast.id), duration);
  }

  remove(id: number) {
    this.toasts = this.toasts.filter(t => t.id !== id);
  }
}


