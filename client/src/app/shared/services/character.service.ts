import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Character } from '../models/character';
import { CharacterCardViewDto } from '../models/character-card-view-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  baseUrl = 'https://localhost:7008/api/characters/';
  private http = inject(HttpClient);

  getCharacter(id: number) {
    return this.http.get<Character>(this.baseUrl + `${id}`)
  }

  getCharacters(){
    return this.http.get<CharacterCardViewDto[]>(this.baseUrl)
  }

  createCharacter(character: any): Observable<any> {
    return this.http.post(`${this.baseUrl}`, character);
  }

  uploadAvatar(formData: FormData): Observable<any> {
    return this.http.post(`${this.baseUrl}upload-avatar`, formData);
  }
}
