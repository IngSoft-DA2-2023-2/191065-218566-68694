export class UserResponse {
    id: number;
    email: string;
    password: string;
    address: string;
    roles: Array<string>;

    constructor() {
        this.id = 0;
        this.password = '';
        this.email = '';
        this.address = '';
        this.roles = new Array<string>;
    }
}