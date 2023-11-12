import { Component, Input } from '@angular/core';
import { ProductResponse } from 'src/app/models/product-models/product-response';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent {
  @Input() product: ProductResponse = new ProductResponse();

}
