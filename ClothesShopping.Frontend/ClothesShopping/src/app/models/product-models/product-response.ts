import { BrandResponse } from "../brand-models/brand-response";
import { CategoryResponse } from "../category-models/category-response";
import { ColorResponse } from "../color-models/color-response";

export class ProductResponse {
    id: number;
    name: string;
    price: number;
    description: string;
    brand: BrandResponse;
    category: CategoryResponse;
    colors: Array<ColorResponse>;
    stock: number;
    promoAvailable: boolean;


    constructor() {
        this.id = 0;
        this.name = '';
        this.price = 0;
        this.description = '';
        this.brand = new BrandResponse();
        this.category = new CategoryResponse();
        this.colors = new Array<ColorResponse>();
        this.stock = 0;
        this.promoAvailable = true;
    }
}