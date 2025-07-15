import { Component } from '@angular/core';
import { ServerService } from '../../services/server.service';
import { Subscription, switchMap, timer } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-server-status',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './server-status.component.html',
    styleUrl: './server-status.component.css'
})
export class ServerStatusComponent {
    isOnline: boolean = false;
    private subscription: Subscription = new Subscription();
    constructor(private readonly serverService: ServerService) { }

    ngOnInit(): void {
        // Atualiza imediatamente e depois a cada 30 segundos
        this.subscription = timer(0, 30000).pipe(
            switchMap(() => this.serverService.getServerStatus())
        ).subscribe((isOnline) => {
            console.log(isOnline);
            this.isOnline = isOnline;
        });
    }

    ngOnDestroy(): void {
        // Limpa a subscription quando o componente for destruído
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
} 