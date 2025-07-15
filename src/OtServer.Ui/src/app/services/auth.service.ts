import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private loggedIn = new BehaviorSubject<boolean>(!!localStorage.getItem('token'));
    isLoggedIn$ = this.loggedIn.asObservable();

    login(token: string, account: string) {
        localStorage.setItem('token', token);
        localStorage.setItem('account', account);
        this.loggedIn.next(true);
    }

    logout() {
        localStorage.removeItem('token');
        localStorage.removeItem('account');
        this.loggedIn.next(false);
    }

    checkLogin() {
        this.loggedIn.next(!!localStorage.getItem('token'));
    }
} 