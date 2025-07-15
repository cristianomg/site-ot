import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeathList } from '../../models/player.model';
import { DeathlistService } from '../../services/deathlist.service';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-deathlist',
    standalone: true,
    imports: [CommonModule, RouterModule],
    templateUrl: './deathlist.component.html',
    styleUrl: './deathlist.component.css'
})
export class DeathlistComponent implements OnInit {
    deaths: DeathList[] = [];
    loading = true;
    error: string | null = null;

    constructor(private readonly deathlistService: DeathlistService) { }

    ngOnInit(): void {
        this.deathlistService.getDeathList().subscribe({
            next: (deaths) => {
                console.log(deaths);
                this.deaths = deaths;
                this.loading = false;
            },
            error: (err) => {
                this.error = 'Erro ao carregar as últimas mortes.';
                this.loading = false;
            }
        });
    }
} 