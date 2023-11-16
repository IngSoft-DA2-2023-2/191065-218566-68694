export class PromotionResponse {
    id: number;
    name: string;
    description: string;
    available: boolean;

    constructor() {
        this.id = 0;
        this.name = '';
        this.description = '';
        this.available = true;
    }
}
