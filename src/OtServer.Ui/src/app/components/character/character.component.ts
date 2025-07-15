import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Player, VocationEnum, SexEnum, DeathList } from '../../models/player.model';

@Component({
    selector: 'app-character',
    standalone: true,
    imports: [RouterLink, CommonModule],
    templateUrl: './character.component.html',
    styleUrl: './character.component.css'
})
export class CharacterComponent implements OnInit {
    player: Player | null = null;
    deaths: DeathList[] = [];
    otherCharacters: Player[] = [];

    constructor(private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            const characterName = params['name'];
            this.loadCharacter(characterName);
        });
    }

    loadCharacter(name: string): void {
        // Mock data - em uma aplicação real, isso viria de uma API
        this.player = this.generateMockPlayer(name);
        // this.deaths = null;
        this.otherCharacters = this.generateMockOtherCharacters();
    }

    generateMockPlayer(name: string): Player {
        const vocations = [1, 2, 3, 4];
        const level = 100 + Math.floor(Math.random() * 50);
        const resets = Math.floor(Math.random() * 30);
        const magicLevel = 80 + Math.floor(Math.random() * 50);
        const skillLevel = 90 + Math.floor(Math.random() * 40);
        const health = 1000 + Math.floor(Math.random() * 500);
        const mana = 600 + Math.floor(Math.random() * 300);

        return {
            id: 1,
            name: name,
            level: level,
            vocation: vocations[Math.floor(Math.random() * vocations.length)],
            sex: Math.floor(Math.random() * 2),
            resets: resets,
            experience: Math.floor(Math.random() * 999999999),
            health: health,
            healthMax: health + Math.floor(Math.random() * 200),
            mana: mana,
            manaMax: mana + Math.floor(Math.random() * 200),
            soul: 100,
            soulMax: 100,
            cap: 1500 + Math.floor(Math.random() * 500),
            magicLevel: magicLevel,
            skillLevel: skillLevel,
            access: 0,
            lastLogin: new Date().toISOString(),
            guild: Math.random() > 0.5 ? { id: 1, guildName: 'Legião Negra' } : undefined,
            guildRank: Math.random() > 0.5 ? 'Membro' : undefined,
            guildNick: Math.random() > 0.5 ? name : undefined
        };
    }


    generateMockOtherCharacters(): Player[] {
        const names = ['Sauron', 'Nazgul', 'Morgoth', 'Balrog', 'Orc'];
        const vocations = [1, 2, 3, 4];
        const characters: Player[] = [];

        for (let i = 0; i < Math.floor(Math.random() * 3); i++) {
            characters.push({
                id: i + 2,
                name: `${names[Math.floor(Math.random() * names.length)]}_${i}`,
                level: 50 + Math.floor(Math.random() * 100),
                vocation: vocations[Math.floor(Math.random() * vocations.length)],
                sex: Math.floor(Math.random() * 2),
                resets: Math.floor(Math.random() * 20),
                experience: Math.floor(Math.random() * 999999999),
                health: 800 + Math.floor(Math.random() * 400),
                healthMax: 800 + Math.floor(Math.random() * 400),
                mana: 400 + Math.floor(Math.random() * 300),
                manaMax: 400 + Math.floor(Math.random() * 300),
                soul: 100,
                soulMax: 100,
                cap: 1200 + Math.floor(Math.random() * 600),
                magicLevel: 60 + Math.floor(Math.random() * 50),
                skillLevel: 70 + Math.floor(Math.random() * 40),
                access: 0,
                lastLogin: new Date().toISOString()
            });
        }

        return characters;
    }

    getVocationName(vocation: number): string {
        switch (vocation) {
            case VocationEnum.Sorcerer: return 'Sorcerer';
            case VocationEnum.Druid: return 'Druid';
            case VocationEnum.Paladin: return 'Paladin';
            case VocationEnum.Knight: return 'Knight';
            default: return 'Desconhecida';
        }
    }

    getSexName(sex: number): string {
        switch (sex) {
            case SexEnum.Male: return 'Masculino';
            case SexEnum.Female: return 'Feminino';
            default: return 'Desconhecido';
        }
    }

    formatDate(dateString: string): string {
        return new Date(dateString).toLocaleString('pt-BR');
    }
} 