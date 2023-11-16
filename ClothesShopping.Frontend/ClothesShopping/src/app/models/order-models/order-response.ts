import { ProductInCart } from "../product-models/product-in-cart";

export class OrderResponse {
    id: number;    
    subTotal: number;
    discount: number;
    total: number;
    cartDate: Date;
    userId:number;
    email:string;
    promotionApplied:string;
    paymentApplied: string;
    products: ProductInCart[];    
    
     
    constructor() {
        this.id = 0;
        this.subTotal = 0;
        this.discount = 0;
        this.total = 0;
        this.cartDate = new Date();
        this.products =[];
        this.userId = 0;
        this.email = "";
        this.promotionApplied="";
        this.paymentApplied = "";               
    }
}


        

