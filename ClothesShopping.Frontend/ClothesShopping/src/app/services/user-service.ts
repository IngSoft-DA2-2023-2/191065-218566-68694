import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../environments.ts/environment';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';
import { UserUpdate } from '../models/user-models/user-update';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService<any> {
  constructor(public http: HttpClient) {
    super(http, environment.url + 'users');
  }

  updateUser(user: UserUpdate): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = environment.url + 'users'; // Ruta de tu API para actualizar usuarios
    return this.http.patch(url, user, { headers });
  }
}
