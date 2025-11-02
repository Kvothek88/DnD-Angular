import { Component, signal } from '@angular/core';
import { CharacterMain } from './character/character-main/character-main';
import { ToastComponent } from "./shared/components/toast/toast";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-root',
  imports: [ToastComponent, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('dnd');
}
