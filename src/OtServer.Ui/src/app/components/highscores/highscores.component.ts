import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Player, PlayerHighscore, RankingType, VocationEnum } from '../../models/player.model';
import { HighscoresService } from '../../services/highscores.service';
import { SkillEnum } from '../../models/skill.model';
import { Observable } from 'rxjs';

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
    players: PlayerHighscore[] = [];

    constructor(private readonly highscoresService: HighscoresService) { }


    ngOnInit(): void {
        this.loadPlayers();
    }

    changeRankingType(type: string, event?: Event): void {
        if (event) {
            event.preventDefault();
        }
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
        switch (this.currentRankingType) {
            case 'level':
                this.mapPlayers(this.highscoresService.getPlayersByLevel(this.currentPage));
                break;
            case 'magiclevel':
                this.mapPlayers(this.highscoresService.getPlayersByMagicLevel(this.currentPage));
                break;
            case 'fist':
                this.mapPlayers(this.highscoresService.getPlayersBySkill(SkillEnum.Fist, this.currentPage));
                break;
            case 'sword':
                this.mapPlayers(this.highscoresService.getPlayersBySkill(SkillEnum.Sword, this.currentPage));
                break;
            case 'distance':
                this.mapPlayers(this.highscoresService.getPlayersBySkill(SkillEnum.Distance, this.currentPage));
                break;
            case 'axe':
                this.mapPlayers(this.highscoresService.getPlayersBySkill(SkillEnum.Axe, this.currentPage));
                break;
            case 'club':
                this.mapPlayers(this.highscoresService.getPlayersBySkill(SkillEnum.Club, this.currentPage));
                break;
            default:
                this.mapPlayers(this.highscoresService.getPlayersByLevel(this.currentPage));
                break;
        }
    }
    mapPlayers(observable: Observable<PlayerHighscore[]>) {
        observable.subscribe((players) => {
            this.players = players.map((player, index) => {
                return {
                    ...player,
                    position: index + 1
                };
            });
            this.totalPages = Math.ceil(this.players.length / 20);
        });
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

    getSkillValue(player: PlayerHighscore): number {
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