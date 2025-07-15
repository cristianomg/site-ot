import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ServerStatusComponent } from './components/server-status/server-status.component';
import { OnlinePlayersComponent } from './components/online-players/online-players.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, ServerStatusComponent, OnlinePlayersComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'dungeon-souls-angular';

    showComingSoon(event: Event): void {
        event.preventDefault();
        alert('Em breve! Esta funcionalidade será implementada nas próximas versões das trevas!');
    }
} 