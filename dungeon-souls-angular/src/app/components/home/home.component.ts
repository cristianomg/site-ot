import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ServerStatusComponent } from '../server-status/server-status.component';
import { OnlinePlayersComponent } from '../online-players/online-players.component';
import { Player } from '../../models/player.model';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [RouterLink, CommonModule, ServerStatusComponent, OnlinePlayersComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent {
    topPlayers: Player[] = [
        {
            id: 1,
            name: 'Sauron',
            level: 150,
            vocation: 4,
            sex: 0,
            resets: 25,
            experience: 999999999,
            health: 1500,
            healthMax: 1500,
            mana: 800,
            manaMax: 800,
            soul: 100,
            soulMax: 100,
            cap: 2000,
            magicLevel: 120,
            skillLevel: 130,
            access: 0,
            lastLogin: '2025-01-15 10:30:00',
            position: 1
        },
        {
            id: 2,
            name: 'Nazgul',
            level: 145,
            vocation: 3,
            sex: 0,
            resets: 22,
            experience: 888888888,
            health: 1400,
            healthMax: 1400,
            mana: 750,
            manaMax: 750,
            soul: 100,
            soulMax: 100,
            cap: 1900,
            magicLevel: 115,
            skillLevel: 125,
            access: 0,
            lastLogin: '2025-01-15 09:15:00',
            position: 2
        },
        {
            id: 3,
            name: 'Morgoth',
            level: 140,
            vocation: 1,
            sex: 0,
            resets: 20,
            experience: 777777777,
            health: 1200,
            healthMax: 1200,
            mana: 900,
            manaMax: 900,
            soul: 100,
            soulMax: 100,
            cap: 1800,
            magicLevel: 130,
            skillLevel: 110,
            access: 0,
            lastLogin: '2025-01-15 08:45:00',
            position: 3
        },
        {
            id: 4,
            name: 'Balrog',
            level: 135,
            vocation: 4,
            sex: 0,
            resets: 18,
            experience: 666666666,
            health: 1300,
            healthMax: 1300,
            mana: 600,
            manaMax: 600,
            soul: 100,
            soulMax: 100,
            cap: 1700,
            magicLevel: 100,
            skillLevel: 135,
            access: 0,
            lastLogin: '2025-01-15 07:30:00',
            position: 4
        },
        {
            id: 5,
            name: 'Orc',
            level: 130,
            vocation: 2,
            sex: 0,
            resets: 15,
            experience: 555555555,
            health: 1100,
            healthMax: 1100,
            mana: 850,
            manaMax: 850,
            soul: 100,
            soulMax: 100,
            cap: 1600,
            magicLevel: 125,
            skillLevel: 105,
            access: 0,
            lastLogin: '2025-01-15 06:20:00',
            position: 5
        }
    ];

    showComingSoon(): void {
        alert('Em breve! Esta funcionalidade será implementada nas próximas versões das trevas!');
    }
} 