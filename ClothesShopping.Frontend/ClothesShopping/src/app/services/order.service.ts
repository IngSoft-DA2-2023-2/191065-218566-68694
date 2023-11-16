import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments.ts/environment';
import { BaseService } from './base-service';

@Injectable({
  providedIn: 'root'
})
export class OrderService extends BaseService<any> {

  constructor(public http: HttpClient) {    
    super(http, environment.url + 'shoppingCarts/sales')
   }
}



9