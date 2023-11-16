import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { OrderResponse } from 'src/app/models/order-models/order-response';
import { OrderService } from 'src/app/services/order.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { operation_crud, pagination_default, pagination_options } from 'src/app/constants/generic-values';
import { OrderDetailComponent } from '../order-detail/order-detail.component';

@Component({
  selector: 'app-orders-admin',
  templateUrl: './orders-admin.component.html',
  styleUrls: ['./orders-admin.component.css']
})
export class OrdersAdminComponent  implements OnInit{
  displayedColumns: string[] = ['orderId', 'userId','email','subTotal', 'discount', 'total' , 'promotion', 'payment', 'actions'];
      
  orderSelected:OrderResponse = new OrderResponse();
  orders: OrderResponse[] = new Array<OrderResponse>();  

  @ViewChild('modalFormOrderDetail', { static: false })
  modalFormOrderDetail!: TemplateRef<any>;



  paginationDefault = pagination_default;
  paginationOps = pagination_options;
  paginatorLength: number = 0;

  ordersTable = new MatTableDataSource<OrderResponse>(this.orders);
    
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;


  constructor(
    public orderService: OrderService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
  ) { }  
  
  ngOnInit(): void {
    this.initPagination();
    this.getOrders()    
  }

  private initPagination(): void {
    this.ordersTable = new MatTableDataSource<OrderResponse>();   
    this.ordersTable.paginator = this.paginator;
    this.ordersTable.sort = this.sort;     
  }
  public applyFilter(event: any): void {
    let filterValue = event.target.value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.ordersTable.filter = filterValue;
  }

  public getOrders(): void {
    this.orderService.getAll().subscribe(
      (response) => {
        this.orders = response as OrderResponse[];
        this.ordersTable = new MatTableDataSource<OrderResponse>(response);
        this.ordersTable.paginator = this.paginator;
        this.ordersTable.sort = this.sort;
        this.paginatorLength = this.orders.length;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de ordenes.',
          'Accept'
        );
      }
    );
  }

  public openModalOrderDetail(order:OrderResponse): void {
    this.orderSelected = order;
    this.dialog.open(this.modalFormOrderDetail);
    const dialogRef = this.dialog.open(this.modalFormOrderDetail);
  } 

}





