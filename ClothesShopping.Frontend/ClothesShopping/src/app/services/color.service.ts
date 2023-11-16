import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments.ts/environment';

@Injectable({
  providedIn: 'root'
})
export class ColorService extends BaseService<any> {

  constructor(public http: HttpClient) {
    super(http, environment.url + 'colors');
  }
}
