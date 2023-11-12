import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  menuItems = [
    { icon: 'shopping_basket', title: 'Productos', route: '' },
    { icon: 'receipt', title: 'Ordenes de compra', route: '' },
    { icon: 'person', title: 'Usuarios', route: '' },
  ];
}
