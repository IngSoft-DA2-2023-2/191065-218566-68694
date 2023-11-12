import { Component } from '@angular/core';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent {
  menuItems = [
    { icon: 'shopping_basket', title: 'Productos', route: '/products-admin' },
    { icon: 'receipt', title: 'Ordenes de compra', route: '/orders' },
    { icon: 'person', title: 'Usuarios', route: '/users' },
    { icon: 'local_offer', title: 'Promociones', route: '/promotions' },
  ];
}
