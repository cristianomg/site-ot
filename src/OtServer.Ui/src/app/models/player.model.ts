export interface Player {
  id: number;
  name: string;
  level: number;
  vocation: number;
  sex: number;
  resets: number;
  experience: number;
  health: number;
  healthMax: number;
  mana: number;
  manaMax: number;
  soul: number;
  soulMax: number;
  cap: number;
  magicLevel: number;
  skillLevel: number;
  access: number;
  lastLogin: string;
  position?: number;
  guild?: Guild;
  guildRank?: string;
  guildNick?: string;
}

export interface PlayerHighscore {
  position: number;
  name: string;
  level: number;
  vocation: string;
  resets: number;
  magicLevel: number;
  experience: number;
  skillLevel: number;
}

export interface PlayerInfo {
  name: string;
  level: number;
  vocation: string;
  resets: number;
  experience: number;
  magicLevel: number;
  health: number;
  healthMax: number;
  mana: number;
  manaMax: number;
  guild?: Guild;
  guildRank?: string;
  guildNick?: string;
}

export interface Guild {
  id: number;
  guildName: string;
}

export interface DeathList {
  level: number;
  playerId: number,
  playerName: string,
  date: string,
  killerName: string,
  killerIsPlayer: boolean,
}

export enum RankingType {
  Level = 'level',
  MagicLevel = 'magiclevel',
  Fist = 'fist',
  Sword = 'sword',
  Distance = 'distance',
  Axe = 'axe',
  Club = 'club'
}

export enum VocationEnum {
  Sorcerer = 1,
  Druid = 2,
  Paladin = 3,
  Knight = 4
}

export enum SexEnum {
  Male = 0,
  Female = 1
}

export interface PlayerCreate {
  name: string;
  sex: SexEnum;
  vocation: VocationEnum;
}
