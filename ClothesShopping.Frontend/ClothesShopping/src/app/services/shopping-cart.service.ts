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

  removeProductToCart(shoppingCartId: number, productId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/remove/${shoppingCartId}`;
    return this.http.patch(url, productId);
  }

  getShoppingCartByUserId(userId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/byUserId/${userId}`;
    return this.http.get(url);
  }

  getDiscount(shoppingCartId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/discount/${shoppingCartId}`;
    return this.http.get(url);
  }
  getTotal(shoppingCartId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/total/${shoppingCartId}`;
    return this.http.get(url);
  }

  makeSale(shoppingCartId: number, paymentId: number): Observable<any> {
    const url = `${environment.url}shoppingCarts/sales/${shoppingCartId}`;
    return this.http.patch(url, paymentId);
  }
}
