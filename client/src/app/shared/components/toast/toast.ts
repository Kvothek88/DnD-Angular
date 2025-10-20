import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastService, Toast } from '../../services/toast.service';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './toast.html',
  styleUrls: ['./toast.css']
})
export class ToastComponent {
  constructor(public toastService: ToastService) {}

  get toasts(): Toast[] {
    return this.toastService.toasts;
  }

  removeToast(toast: Toast) {
    this.toastService.remove(toast.id);
  }
}

