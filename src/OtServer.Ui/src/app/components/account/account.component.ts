import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/account.model';

@Component({
    selector: 'app-account',
    standalone: true,
    imports: [CommonModule, RouterModule],
    templateUrl: './account.component.html',
    styleUrl: './account.component.css'
})
export class AccountComponent implements OnInit {
    accountData: any = null;
    loading = true;
    error: string | null = null;

    constructor(private accountService: AccountService, private router: Router) { }

    ngOnInit(): void {
        const account = localStorage.getItem('account');
        if (!account) {
            this.router.navigate(['/login']);
            return;
        }

        this.accountService.getByAccount(account).subscribe({
            next: (data: Account) => {
                this.accountData = data;
                this.loading = false;
            },
            error: (err: any) => {
                this.error = 'Erro ao carregar dados da conta.';
                this.loading = false;
            }
        });
    }

    criarPersonagem() {
        // Lógica para criar personagem (ex: abrir modal ou redirecionar)
        alert('Redirecionar para tela de criação de personagem.');
    }

    alterarSenha() {
        alert('Redirecionar para tela de alteração de senha.');
    }

    alterarEmail() {
        alert('Redirecionar para tela de alteração de email.');
    }

    deletarPersonagem(player: any) {
        alert('Deletar personagem: ' + player.name);
    }
} 