import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { DeathList } from '../models/player.model';

@Injectable({
    providedIn: 'root'
})
export class DeathlistService {
    constructor(private readonly http: HttpClient) { }

    getDeathList(): Observable<DeathList[]> {
        return this.http.get<DeathList[]>(`${environment.apiUrl}/deathlist`);
    }
} 