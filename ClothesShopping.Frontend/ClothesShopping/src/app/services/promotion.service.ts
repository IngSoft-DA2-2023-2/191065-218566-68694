import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments.ts/environment';
import { BaseService } from './base-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PromotionService extends BaseService<any> {

  constructor(public http: HttpClient) {
    super(http, environment.url + 'promotions');
  }
  activePromotion(id: number): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = environment.url + 'promotions/active/' + id;
    return this.http.patch(url, {},{ headers});
  }
  deactivePromotion(id: number): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = environment.url + 'promotions/deactive/' + id;
    return this.http.patch(url, {}, { headers });
  }
}

