import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { environment } from 'src/environments.ts/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BrandService extends BaseService<any> {

  constructor(public http: HttpClient) {
    super(http, environment.url + 'brands');
  }
}
