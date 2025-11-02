import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { CharacterMain } from './character/character-main/character-main';

export const routes: Routes = [
    {path:'', component: Home},
    {path:'character/:id', component: CharacterMain},
    { path: '**', redirectTo: '' }
];
