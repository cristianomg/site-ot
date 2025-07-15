import { Component, OnDestroy, OnInit } from '@angular/core';
import { ServerService } from '../../services/server.service';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-online-players',
    standalone: true,
    imports: [],
    templateUrl: './online-players.component.html',
    styleUrl: './online-players.component.css'
})
export class OnlinePlayersComponent implements OnInit, OnDestroy {
    playersOnline: number = 0;
    private subscription: Subscription = new Subscription();

    constructor(private readonly serverService: ServerService) { }

    ngOnInit(): void {
        // Atualiza imediatamente e depois a cada 30 segundos
        this.subscription = timer(0, 30000).pipe(
            switchMap(() => this.serverService.getOnlineList())
        ).subscribe((players) => {
            this.playersOnline = players.length;
        });
    }

    ngOnDestroy(): void {
        // Limpa a subscription quando o componente for destruído
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
} 