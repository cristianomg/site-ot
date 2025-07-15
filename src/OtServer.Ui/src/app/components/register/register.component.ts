import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { AccountCreate } from '../../models/account.model';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './register.component.html',
    styleUrl: './register.component.css'
})
export class RegisterComponent {
    registerForm: FormGroup;
    showErrorToast = false;
    errorMessage = '';

    constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {
        this.registerForm = this.fb.group({
            nome: ['', Validators.required],
            account: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', [Validators.required]],
            location: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]]
        }, { validators: this.passwordMatchValidator });
    }

    passwordMatchValidator(form: FormGroup) {
        return form.get('password')!.value === form.get('confirmPassword')!.value ? null : { mismatch: true };
    }

    criarConta() {
        if (this.registerForm.invalid) {
            this.registerForm.markAllAsTouched();
            this.errorMessage = 'Preencha todos os campos corretamente para criar a conta.';
            this.showErrorToast = true;
            return;
        }

        const account = {
            account: this.registerForm.value.account,
            password: this.registerForm.value.password,
            email: this.registerForm.value.email,
            realName: this.registerForm.value.nome,
            location: this.registerForm.value.location
        } as AccountCreate;

        console.log(account);
        this.accountService.create(account).subscribe({
            next: (response: string) => {
                this.router.navigate(['/login']);
            },
            error: (error: any) => {
                this.errorMessage = error?.error || 'Erro ao criar conta.';
                this.showErrorToast = true;
            }
        });
    }
} 