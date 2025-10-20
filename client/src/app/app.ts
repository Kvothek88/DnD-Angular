import { Component, signal } from '@angular/core';
import { CharacterMain } from './character/character-main/character-main';



@Component({
  selector: 'app-root',
  imports: [CharacterMain],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('dnd');
}
