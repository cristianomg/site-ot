import { Component, OnInit } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { ServerStatusComponent } from './components/server-status/server-status.component';
import { OnlinePlayersComponent } from './components/online-players/online-players.component';
import { AuthService } from './services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive, ServerStatusComponent, OnlinePlayersComponent, CommonModule],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
    title = 'dungeon-souls-angular';
    isLoggedIn = false;

    constructor(private authService: AuthService) { }

    ngOnInit() {
        this.authService.isLoggedIn$.subscribe(status => {
            this.isLoggedIn = status;
        });
    }

    showComingSoon(event: Event): void {
        event.preventDefault();
        alert('Em breve! Esta funcionalidade será implementada nas próximas versões das trevas!');
    }

    logout() {
        this.authService.logout();
        window.location.href = '/login';
    }
} 