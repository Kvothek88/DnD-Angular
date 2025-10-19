import { Component, signal } from '@angular/core';
import { CharacterDashboard } from "./character/character-dashboard/character-dashboard";

@Component({
  selector: 'app-root',
  imports: [CharacterDashboard],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('dnd');
}
