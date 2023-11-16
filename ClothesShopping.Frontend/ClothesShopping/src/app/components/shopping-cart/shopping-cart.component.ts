import { Component } from '@angular/core';
import { ShoppingCartResponse } from 'src/app/models/shopping-cart-models/shopping-cart-response';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent {
  public cartData: ShoppingCartResponse;

  constructor() {
    this.cartData = {
      Id: 1,
      UserId: 123,
      Email: 'user@example.com',
      SubTotal: 100.0,
      Discount: 10.0,
      Total: 90.0,
      CartDate: new Date(),
      Products: [
        { id: 1, name: 'Product A', price: 30},
        { id: 2, name: 'Product B' , price: 30},
        { id: 3, name: 'Product C', price: 40},
      ]
    };
  }
}
