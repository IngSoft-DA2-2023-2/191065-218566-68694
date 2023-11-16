import { Component, Input } from '@angular/core';
import { OrderResponse } from 'src/app/models/order-models/order-response';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent {
  @Input() order: OrderResponse = new OrderResponse();  

  constructor(private dialogRef: MatDialogRef<OrderDetailComponent>) { }

  closeModal(): void {
    this.dialogRef.close();
  }


}

