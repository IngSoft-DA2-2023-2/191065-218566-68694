import { ProductInCart } from "../product-models/product-in-cart";

export class ShoppingCartResponse {
    Id: number;
    UserId: number;
    Email: string;
    SubTotal: number;
    Discount: number;
    Total: number;
    CartDate: Date;
    Products: ProductInCart[];
  
    constructor() {
      this.Id = 0;
      this.UserId = 0;
      this.Email = '';
      this.SubTotal = 0;
      this.Discount = 0;
      this.Total = 0;
      this.CartDate = new Date();
      this.Products = [];
    }
  }
  
