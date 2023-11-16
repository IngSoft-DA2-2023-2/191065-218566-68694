import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments.ts/environment';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService extends BaseService<any>{

  constructor(public http: HttpClient) {
    super(http, environment.url + 'shoppingCarts');
  }

  addProductToCart(shoppingCartId: number, productId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/add/${shoppingCartId}`;
    return this.http.patch(url, productId);
  }

  getShoppingCartByUserId(userId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/byUserId/${userId}`;
    return this.http.get(url);
  }
}
