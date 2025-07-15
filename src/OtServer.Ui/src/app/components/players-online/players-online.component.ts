import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Player, PlayerInfo, VocationEnum } from '../../models/player.model';
import { ServerService } from '../../services/server.service';

@Component({
    selector: 'app-players-online',
    standalone: true,
    imports: [RouterLink, CommonModule],
    templateUrl: './players-online.component.html',
    styleUrl: './players-online.component.css'
})
export class PlayersOnlineComponent implements OnInit {
    playersOnline: PlayerInfo[] = [];

    constructor(private readonly serverService: ServerService) { }

    ngOnInit(): void {
        this.loadOnlinePlayers();
    }

    loadOnlinePlayers(): void {
        // Mock data - em uma aplicação real, isso viria de uma API
        this.serverService.getOnlineList().subscribe((players) => {
            this.playersOnline = players;
        });
    }
} 