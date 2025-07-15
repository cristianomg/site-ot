import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Player, VocationEnum } from '../../models/player.model';

@Component({
    selector: 'app-players-online',
    standalone: true,
    imports: [RouterLink, CommonModule],
    templateUrl: './players-online.component.html',
    styleUrl: './players-online.component.css'
})
export class PlayersOnlineComponent implements OnInit {
    playersOnline: Player[] = [];

    ngOnInit(): void {
        this.loadOnlinePlayers();
    }

    loadOnlinePlayers(): void {
        // Mock data - em uma aplicação real, isso viria de uma API
        this.playersOnline = this.generateMockOnlinePlayers();
    }

    generateMockOnlinePlayers(): Player[] {
        const mockPlayers: Player[] = [];
        const names = ['Sauron', 'Nazgul', 'Morgoth', 'Balrog', 'Orc', 'Goblin', 'Troll', 'Dragon', 'Witch', 'Demon'];
        const vocations = [1, 2, 3, 4];
        const guilds = ['Legião Negra', 'Ordem Sombria', 'Clã das Trevas', 'Irmandade do Mal', null];

        for (let i = 1; i <= 15; i++) {
            const vocation = vocations[Math.floor(Math.random() * vocations.length)];
            const level = 50 + Math.floor(Math.random() * 100);
            const guild = guilds[Math.floor(Math.random() * guilds.length)];
            const health = 800 + Math.floor(Math.random() * 700);
            const mana = 400 + Math.floor(Math.random() * 500);

            mockPlayers.push({
                id: i,
                name: `${names[Math.floor(Math.random() * names.length)]}_${i}`,
                level: level,
                vocation: vocation,
                sex: Math.floor(Math.random() * 2),
                resets: Math.floor(Math.random() * 20),
                experience: Math.floor(Math.random() * 999999999),
                health: health,
                healthMax: health + Math.floor(Math.random() * 200),
                mana: mana,
                manaMax: mana + Math.floor(Math.random() * 200),
                soul: 100,
                soulMax: 100,
                cap: 1200 + Math.floor(Math.random() * 800),
                magicLevel: 60 + Math.floor(Math.random() * 70),
                skillLevel: 70 + Math.floor(Math.random() * 60),
                access: 0,
                lastLogin: new Date().toISOString(),
                guild: guild ? { id: i, guildName: guild } : undefined,
                guildRank: guild ? ['Líder', 'Vice-líder', 'Membro', 'Recruta'][Math.floor(Math.random() * 4)] : undefined
            });
        }

        return mockPlayers;
    }

    getVocationName(vocation: number): string {
        switch (vocation) {
            case VocationEnum.None: return 'Nenhuma';
            case VocationEnum.Sorcerer: return 'Sorcerer';
            case VocationEnum.Druid: return 'Druid';
            case VocationEnum.Paladin: return 'Paladin';
            case VocationEnum.Knight: return 'Knight';
            default: return 'Desconhecida';
        }
    }
} 