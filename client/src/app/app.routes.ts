import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { CharacterMain } from './character/character-main/character-main';
import { CharacterMenu } from './features/character-menu/character-menu';

export const routes: Routes = [
    {
        path: '',
        component: Home,
        children: [
            { path: '', redirectTo: 'characters', pathMatch: 'full' },
            { path: 'characters', component: CharacterMenu },
        ]
    },
    { path:'characters/:id', component: CharacterMain },
    { path: '**', redirectTo: '' }
];
