import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ServerStatusComponent } from '../server-status/server-status.component';
import { OnlinePlayersComponent } from '../online-players/online-players.component';
import { Player, PlayerHighscore } from '../../models/player.model';
import { HighscoresService } from '../../services/highscores.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [RouterLink, CommonModule, ServerStatusComponent, OnlinePlayersComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

    topPlayers: PlayerHighscore[] = [

    ];
    constructor(private readonly highscoresService: HighscoresService) { }

    ngOnInit(): void {
        this.loadPlayers();
    }

    loadPlayers(): void {
        this.mapPlayers(this.highscoresService.getPlayersByLevel(1));
    }

    mapPlayers(observable: Observable<PlayerHighscore[]>) {
        observable.subscribe((players) => {
            this.topPlayers = players.map((player, index) => {
                return {
                    ...player,
                    position: index + 1
                };
            }).slice(0, 5);
        });
    }

    showComingSoon(): void {
        alert('Em breve! Esta funcionalidade será implementada nas próximas versões das trevas!');
    }
} 