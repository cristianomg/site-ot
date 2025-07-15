import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Account, AccountCreate, LoginResponse } from '../models/account.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  login(account: string, password: string) {
    return this.http.post<LoginResponse>(`${environment.apiUrl}/account/login`, { account, password });
  }

  getByAccount(account: string) {
    return this.http.get<Account>(`${environment.apiUrl}/account/${account}`);
  }

  create(account: AccountCreate) {
    return this.http.post<string>(`${environment.apiUrl}/account`, account);
  }
}
