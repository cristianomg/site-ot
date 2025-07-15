import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HighscoresComponent } from './components/highscores/highscores.component';
import { PlayersOnlineComponent } from './components/players-online/players-online.component';
import { CharacterComponent } from './components/character/character.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'highscores', component: HighscoresComponent },
    { path: 'players-online', component: PlayersOnlineComponent },
    { path: 'character/:name', component: CharacterComponent },
    { path: '**', redirectTo: '' }
]; 