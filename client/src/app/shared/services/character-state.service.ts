import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ToastService } from './toast.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterStateService {

  constructor(private toastService: ToastService) {}

  private innateSorceryActive = new BehaviorSubject<boolean>(false);
  innateSorceryActive$ = this.innateSorceryActive.asObservable();

  toggleInnateSorcery() {
    this.innateSorceryActive.next(!this.innateSorceryActive.value);
    let status: string = this.innateSorceryActive.value == true ? 'Active' : 'Inactive'
    this.toastService.show('Innate Sorcery: ' + status, 'magic')
  }

  setInnateSorcery(value: boolean) {
    this.innateSorceryActive.next(value);
  }
}
