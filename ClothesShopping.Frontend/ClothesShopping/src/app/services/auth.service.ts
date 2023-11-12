import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import jwt_decode from 'jwt-decode';
import { SnackBarService } from './snack-bar.service';
import { environment } from 'src/environments.ts/environment';
import { SessionRequest } from '../models/session-models/SessionRequest';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public url: string;
  token = '';

  constructor(
    private http: HttpClient,
    private router: Router,
    public snackBarService: SnackBarService
  ) {
    this.url = environment.url;
  }

  public login(session: SessionRequest): Observable<any> {
    let params = JSON.stringify(session);
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    const requestOptions: Object = {
      headers: headers,
      responseType: 'text',
    };
    return this.http
      .post<any>(this.url + 'sessions', params, requestOptions)
      .pipe(
        map((response) => {
          const session = JSON.parse(response);
          localStorage.setItem('userId', session.userId);
          localStorage.setItem('userEmail', session.email);
          localStorage.setItem('token', session.token);
          console.log(localStorage.getItem('token'));
          console.log(localStorage.getItem('userEmail'));
          return response;
        })
      );
  }

  public getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch (Error) {
      return null;
    }
  }

  public logout(): Observable<any> {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    const requestOptions: Object = {
      headers: headers,
      responseType: 'text',
    };
    return this.http
      .delete<any>(
        this.url + 'sessions/' + localStorage.getItem('token'),
        requestOptions
      )
      .pipe(
        map((response) => {
          localStorage.removeItem('userEmail');
          localStorage.removeItem('token');
          localStorage.removeItem('userId');
          this.router.navigate(['/login']);
          return response;
        })
      );
  }

  public loggedIn() {
    return !!localStorage.getItem('token');
  }

  public getToken() {
    return localStorage.getItem('token');
  }
}
