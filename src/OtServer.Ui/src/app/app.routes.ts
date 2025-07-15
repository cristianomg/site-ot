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
    {
        path: 'ultimas-mortes',
        loadComponent: () => import('./components/deathlist/deathlist.component').then(m => m.DeathlistComponent)
    },
    {
        path: 'regras',
        loadComponent: () => import('./components/rules/rules.component').then(m => m.RulesComponent)
    },
    {
        path: 'shopping-dsp',
        loadComponent: () => import('./components/shopping-dsp/shopping-dsp.component').then(m => m.ShoppingDspComponent)
    },
    {
        path: 'login',
        loadComponent: () => import('./components/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: 'register',
        loadComponent: () => import('./components/register/register.component').then(m => m.RegisterComponent)
    },
    {
        path: 'account',
        canActivate: [() => import('./interceptors/auth.guard').then(m => m.AuthGuard)],
        loadComponent: () => import('./components/account/account.component').then(m => m.AccountComponent)
    },
    {
        path: 'register-character',
        loadComponent: () => import('./components/create-character/create-character.component').then(m => m.CreateCharacterComponent)
    },
    { path: '**', redirectTo: '' }
]; 