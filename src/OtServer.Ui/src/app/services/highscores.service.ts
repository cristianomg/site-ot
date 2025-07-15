import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { PlayerHighscore } from '../models/player.model';
import { SkillEnum } from '../models/skill.model';

@Injectable({
  providedIn: 'root'
})
export class HighscoresService {

  constructor(private readonly http: HttpClient) { }


  getPlayersByLevel(page: number) {
    return this.http.get<PlayerHighscore[]>(`${environment.apiUrl}/rank/level?page=${page}`);
  }
  getPlayersByMagicLevel(page: number) {
    return this.http.get<PlayerHighscore[]>(`${environment.apiUrl}/rank/magiclevel?page=${page}`);
  }
  getPlayersBySkill(skillType: SkillEnum, page: number) {
    return this.http.get<PlayerHighscore[]>(`${environment.apiUrl}/Rank/Skill/${skillType}?page=${page}`);
  }

}
