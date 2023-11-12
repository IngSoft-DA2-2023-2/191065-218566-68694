export class UserRequest {
    email: string;
    password: string;
    address: string;
    roles: Array<string>;

    constructor() {
      this.password = '';
      this.email = '';
      this.address = '';
      this.roles = new Array<string>;
    }
  }
  