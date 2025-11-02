import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CharacterService } from '../../shared/services/character.service';
import { CharacterCardViewDto } from '../../shared/models/character-card-view-dto';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {

  private characterService = inject(CharacterService);
  private cdr = inject(ChangeDetectorRef);

  characters: CharacterCardViewDto[] = [];
  isLoading = true;
  error: string | null = null;

  ngOnInit(): void {
    this.characterService.getCharacters().subscribe({
      next: characters => {
        this.isLoading = false;
        this.characters = characters;
        this.cdr.detectChanges();
        console.log(characters)
      },
      error: err => {
        console.error(err);
        this.error = 'Failed to load characters';
        this.isLoading = false;
      }
    });
  }
}

