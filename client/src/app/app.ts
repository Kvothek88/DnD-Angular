import { Component, signal } from '@angular/core';
import { CharacterMain } from './character/character-main/character-main';
import { ToastComponent } from "./shared/components/toast/toast";



@Component({
  selector: 'app-root',
  imports: [CharacterMain, ToastComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('dnd');
}
