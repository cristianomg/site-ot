import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [CommonModule, FormsModule, RouterModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent {
    username = '';
    password = '';
    showErrorToast = false;
    errorMessage = '';

    constructor(
        private router: Router,
        private accountService: AccountService,
        private authService: AuthService
    ) { }

    logar() {
        this.accountService.login(this.username, this.password).subscribe({
            next: (response) => {
                this.authService.login(response.token, response.account.toString());
                this.router.navigate(['/account']);
            },
            error: (error: any) => {
                if (error?.error.status === 401) {
                    this.errorMessage = "Usuário ou senha inválidos."
                    console.log(error);
                    this.showErrorToast = true;

                }
                else {
                    this.errorMessage = "Erro ao logar. Tente novamente mais tarde.";
                    this.showErrorToast = true;

                }
            }
        });
    }
    recuperarConta() {
        alert('Redirecionar para tela de recuperação de conta.');
    }
} 