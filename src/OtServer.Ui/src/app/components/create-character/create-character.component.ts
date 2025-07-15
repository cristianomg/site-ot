import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PlayerCreate } from '../../models/player.model';
import { PlayerService } from '../../services/player.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-create-character',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './create-character.component.html',
    styleUrl: './create-character.component.css'
})
export class CreateCharacterComponent {
    characterForm: FormGroup;

    vocations = [
        { label: 'Sorcerer', value: 1 },
        { label: 'Druid', value: 2 },
        { label: 'Archer', value: 3 },
        { label: 'Knight', value: 4 },
    ];

    constructor(private fb: FormBuilder, private playerService: PlayerService, private router: Router) {
        this.characterForm = this.fb.group({
            name: ['', Validators.required],
            sex: [0, Validators.required],
            vocation: [1, Validators.required],
        });
    }

    criarPersonagem() {
        if (this.characterForm.invalid) {
            this.characterForm.markAllAsTouched();
            return;
        }

        this.playerService.create(this.characterForm.value as PlayerCreate).subscribe({
            next: (response) => {
                console.log(response);
                this.router.navigate(['/account']);
            },
            error: (error: any) => {
                console.log(error);
            }
        });
    }
} 