import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Player, RankingType, VocationEnum } from '../../models/player.model';

@Component({
    selector: 'app-highscores',
    standalone: true,
    imports: [RouterLink, CommonModule],
    templateUrl: './highscores.component.html',
    styleUrl: './highscores.component.css'
})
export class HighscoresComponent implements OnInit {
    currentRankingType: string = 'level';
    currentPage: number = 1;
    totalPages: number = 1;
    players: Player[] = [];

    ngOnInit(): void {
        this.loadPlayers();
    }

    changeRankingType(type: string): void {
        this.currentRankingType = type;
        this.currentPage = 1;
        this.loadPlayers();
    }

    changePage(page: number, event: Event): void {
        event.preventDefault();
        if (page >= 1 && page <= this.totalPages) {
            this.currentPage = page;
            this.loadPlayers();
        }
    }

    loadPlayers(): void {
        // Mock data - em uma aplicação real, isso viria de uma API
        this.players = this.generateMockPlayers();
        this.totalPages = Math.ceil(this.players.length / 20);
    }

    generateMockPlayers(): Player[] {
        const mockPlayers: Player[] = [];
        const names = ['Sauron', 'Nazgul', 'Morgoth', 'Balrog', 'Orc', 'Goblin', 'Troll', 'Dragon', 'Witch', 'Demon'];
        const vocations = [1, 2, 3, 4];

        for (let i = 1; i <= 50; i++) {
            const vocation = vocations[Math.floor(Math.random() * vocations.length)];
            const level = 100 + Math.floor(Math.random() * 50);
            const resets = Math.floor(Math.random() * 30);
            const magicLevel = 80 + Math.floor(Math.random() * 50);
            const skillLevel = 90 + Math.floor(Math.random() * 40);

            mockPlayers.push({
                id: i,
                name: `${names[Math.floor(Math.random() * names.length)]}_${i}`,
                level: level,
                vocation: vocation,
                sex: Math.floor(Math.random() * 2),
                resets: resets,
                experience: Math.floor(Math.random() * 999999999),
                health: 1000 + Math.floor(Math.random() * 500),
                healthMax: 1000 + Math.floor(Math.random() * 500),
                mana: 600 + Math.floor(Math.random() * 300),
                manaMax: 600 + Math.floor(Math.random() * 300),
                soul: 100,
                soulMax: 100,
                cap: 1500 + Math.floor(Math.random() * 500),
                magicLevel: magicLevel,
                skillLevel: skillLevel,
                access: 0,
                lastLogin: new Date().toISOString(),
                position: i
            });
        }

        // Ordenar baseado no tipo de ranking
        if (this.currentRankingType === 'level') {
            mockPlayers.sort((a, b) => (b.level + b.resets * 100) - (a.level + a.resets * 100));
        } else if (this.currentRankingType === 'magiclevel') {
            mockPlayers.sort((a, b) => b.magicLevel - a.magicLevel);
        } else {
            mockPlayers.sort((a, b) => b.skillLevel - a.skillLevel);
        }

        // Atualizar posições
        mockPlayers.forEach((player, index) => {
            player.position = index + 1;
        });

        return mockPlayers;
    }

    getRankingTitle(): string {
        switch (this.currentRankingType) {
            case 'level': return '⭐ Level & Resets';
            case 'magiclevel': return '🔮 Magic Level';
            case 'fist': return '🛡️ Fist Fighting';
            case 'sword': return '⚔️ Sword Fighting';
            case 'distance': return '🏹 Distance Fighting';
            case 'axe': return '🪓 Axe Fighting';
            case 'club': return '🔨 Club Fighting';
            default: return '⭐ Level & Resets';
        }
    }

    getSkillHeader(): string {
        switch (this.currentRankingType) {
            case 'magiclevel': return '🔮 Magic Level';
            case 'fist': return '🛡️ Fist Skill';
            case 'sword': return '⚔️ Sword Skill';
            case 'distance': return '🏹 Distance Skill';
            case 'axe': return '🪓 Axe Skill';
            case 'club': return '🔨 Club Skill';
            default: return 'Skill';
        }
    }

    isSkillRanking(): boolean {
        return this.currentRankingType !== 'level';
    }

    getSkillValue(player: Player): number {
        if (this.currentRankingType === 'magiclevel') {
            return player.magicLevel;
        }
        return player.skillLevel;
    }

    getSkillColor(value: number): string {
        if (value >= 130) return 'text-danger';
        if (value >= 100) return 'text-warning';
        if (value >= 70) return 'text-info';
        return 'text-muted';
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

    getCurrentDateTime(): string {
        return new Date().toLocaleString('pt-BR');
    }

    getPageNumbers(): number[] {
        const pages: number[] = [];
        const start = Math.max(1, this.currentPage - 2);
        const end = Math.min(this.totalPages, this.currentPage + 2);

        for (let i = start; i <= end; i++) {
            pages.push(i);
        }

        return pages;
    }
} 