import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { ShoppingCartRequest } from 'src/app/models/shopping-cart-models/shopping-cart-request';
import { ProductService } from 'src/app/services/product.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent {
  @Input() product: ProductResponse = new ProductResponse();
  userToken: string | null = localStorage.getItem('token');
  userEmail: string | null = localStorage.getItem('userEmail') || '';
  userId: string | undefined = localStorage.getItem('userId') || '';
  shoppingCartId: string | undefined = localStorage.getItem('shoppingCartId') || '';
  @Output() requestLoginUser: EventEmitter<string> = new EventEmitter();
  @Input() parentProductsComponent: any;
  shoppingCartIdNumber = 0;
  constructor(public dialog: MatDialog, private shoppingCartService: ShoppingCartService, public snackBarService: SnackBarService) {

  }

  public addProductToCart(): void {
    debugger
    if (this.userToken != null && this.userToken != '') {
      this.getShoppingCartByUserId();
    }
    else {
      this.requestLoginUser.emit('request-login-user');
    }
  }

  public getShoppingCartByUserId(): void {

    if (this.userId != null && this.shoppingCartId == "") {
      this.shoppingCartService.getShoppingCartByUserId(parseInt(this.userId, 10)).subscribe(
        (data) => {
          if (data || data.length === 0 || data[0] === null) {
            this.newShoppingCart();
          }
          else {
            localStorage.setItem('shoppingCartId', data.id);
            this.saveProductToCart();
          }
        },
        (error) => {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo agregar el producto al carrito.',
            'Aceptar'
          );
        })
    }
    else {
      this.saveProductToCart();
    }
  }

  public newShoppingCart(): void {
    if (this.userEmail != null) {
      const shoppingCartRequest: ShoppingCartRequest = {
        email: this.userEmail,
      };
      this.shoppingCartService.add(shoppingCartRequest).subscribe(
        (response) => {
          this.snackBarService.successMessage(
            'Se ha ingresado el producto al carrito.',
            'Aceptar'
          );
          localStorage.setItem('shoppingCartId', response);
          this.saveProductToCart();
        },
        (error) => {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo agregar el producto al carrito.',
            'Aceptar'
          );
        })
    }
  }

  public saveProductToCart(): void {
    const shoppingCartId = localStorage.getItem('shoppingCartId') || '';
    console.log("shoppingCartId" + localStorage.getItem('shoppingCartId'));
    this.shoppingCartService.addProductToCart(parseInt(shoppingCartId, 10), this.product.id).subscribe(
      (response) => {
        this.snackBarService.successMessage(
          'Se ha ingresado el producto al carrito.',
          'Aceptar'
        );
        this.dialog.closeAll();
      },
      (error) => {
        if (error.status == 200) {
          this.snackBarService.successMessage(
            'Se ha ingresado el producto al carrito.',
            'Aceptar'
          );
          this.parentProductsComponent.getProducts();
          this.dialog.closeAll();
        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo agregar el producto al carrito.',
            'Aceptar'
          );
        }
      })
  }
}
