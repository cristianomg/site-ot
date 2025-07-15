import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { PlayerInfo } from '../models/player.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  constructor(private readonly http: HttpClient) { }

  getServerStatus(): Observable<boolean> {
    return this.http.get<boolean>(`${environment.apiUrl}/server/status`);
  }

  getOnlineList(): Observable<PlayerInfo[]> {
    return this.http.get<PlayerInfo[]>(`${environment.apiUrl}/server/online-list`);
  }
}
