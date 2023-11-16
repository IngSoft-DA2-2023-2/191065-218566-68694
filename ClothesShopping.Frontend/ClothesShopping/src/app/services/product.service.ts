import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments.ts/environment';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';
import { ProductResponse } from '../models/product-models/product-response';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService<any> {

  constructor(public http: HttpClient) {
    super(http, environment.url + 'products');
  }

  updateProduct(product: ProductResponse): Observable<any> {
    const url = `${environment.url}/api/products`; // Reemplaza con la ruta correcta de tu API

    return this.http.patch(url, product);
  }
}
