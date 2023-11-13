import { BrandResponse } from "../brand-models/brand-response";
import { CategoryResponse } from "../category-models/category-response";
import { ColorResponse } from "../color-models/color-response";

export class ProductRequest {
    name: string;
    price: number;
    description: string;
    brand: number;
    category: number;
    colors: Array<number>;
    stock: number;
    promoAvailable: boolean;


    constructor() {
        this.name = '';
        this.price = 0;
        this.description = '';
        this.brand = 0;
        this.category = 0;
        this.colors = [];
        this.stock = 0;
        this.promoAvailable = true;
    }
}