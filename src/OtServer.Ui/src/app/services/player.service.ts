import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Player, PlayerCreate } from '../models/player.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  constructor(private http: HttpClient) { }


  create(player: PlayerCreate) {
    return this.http.post(`${environment.apiUrl}/player`, player);
  }
}
