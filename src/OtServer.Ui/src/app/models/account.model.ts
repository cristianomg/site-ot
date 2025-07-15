import { PlayerInfo } from "./player.model";

export interface LoginResponse {
    account: number;
    token: string;
}

export interface Account {
    accountNumber: number;
    email: string;
    realName: string;
    location: string;
    players: PlayerInfo[];
}

export interface AccountCreate {
    account: string;
    password: string;
    email: string;
    realName: string;
    location: string;
}