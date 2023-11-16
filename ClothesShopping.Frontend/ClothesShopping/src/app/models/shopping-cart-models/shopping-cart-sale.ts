/*public int Id { get; set; }
public int UserId { get; set; }
public string Email { get; set; }
public double SubTotal { get; set; } = 0;
public double Discount { get; set; } = 0;
public double Total { get; set; } = 0;
public DateTime CartDate { get; set; } = DateTime.Now;
public List<ProductInCartDTO> Products { get; set; }
public string PromotionApplied { get; set; }        */

import { ProductInCart } from "../product-models/product-in-cart";

export class ShoppingCartResponse {
    id: number;
    userId: number;
    email: string;
    subTotal: number;
    discount: number;
    total: number;
    cartDate: Date;
    products: ProductInCart[];
    promotionApplied:string;
    constructor() {
      this.id = 0;
      this.userId = 0;
      this.email = '';
      this.subTotal = 0;
      this.discount = 0;
      this.total = 0;
      this.cartDate = new Date();
      this.products = [];
      this.promotionApplied = '';
    }
  }
  