import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CharacterService } from '../../shared/services/character.service';
import { CharacterCardViewDto } from '../../shared/models/character-card-view-dto';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-character-menu',
  imports: [ RouterModule ],
  templateUrl: './character-menu.html',
  styleUrl: './character-menu.css'
})
export class CharacterMenu implements OnInit {

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
