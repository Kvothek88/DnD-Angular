import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Character } from '../models/character';
import { ReferenceViewDto } from '../models/reference-view-dto';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  baseUrl = 'https://localhost:7008/api/';
  private http = inject(HttpClient);

  getCharacter(id: number) {
    return this.http.get<Character>(this.baseUrl + `characters/${id}`)
  }

  getCharacters(){
    return this.http.get<ReferenceViewDto[]>(this.baseUrl + 'characters')
  }
}
