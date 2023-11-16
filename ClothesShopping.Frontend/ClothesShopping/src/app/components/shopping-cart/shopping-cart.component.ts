import { Component, OnInit } from '@angular/core';
import { ProductInCart } from 'src/app/models/product-models/product-in-cart';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { PromotionDiscount } from 'src/app/models/promotion-models/promotion-discount';
import { PaymentResponse } from 'src/app/models/payment-models/payment-response';
import { ShoppingCartResponse } from 'src/app/models/shopping-cart-models/shopping-cart-response';
import { PaymentService } from 'src/app/services/payment.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  productSelected: ProductInCart = new ProductInCart();
  userId: string | undefined = localStorage.getItem('userId') || '';
  shoppingCartId: string | undefined = localStorage.getItem('shoppingCartId') || '';
  cartData: ShoppingCartResponse = new ShoppingCartResponse();
  discount: number = 0;
  subTotalPrice: number = 0;
  totalPrice: number = 0;
  loadCard: boolean = true;
  promotionDiscount: PromotionDiscount = new PromotionDiscount();
  promoApply: string = '';
  paymentSelected: PaymentResponse = new PaymentResponse();
  paymentResponse: Array<PaymentResponse> = new Array<PaymentResponse>();
  constructor(private shoppingCartService: ShoppingCartService, private snackBarService: SnackBarService, private paymentService: PaymentService) {
  }

  ngOnInit(): void {
    this.getPayments();
    this.getShoppingCartByUserId();
  }

  public getTotal(): void {
    this.shoppingCartService.getTotal(this.cartData.id).subscribe(
      (data) => {
        this.totalPrice = data;
        this.getDiscount();
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener el carrito de compras.',
          'Aceptar'
        );
      })
  }

  public getPayments(): void {
    this.paymentService.getAll().subscribe(
      (data) => {
        this.paymentResponse = data;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener los tipos de pago.',
          'Aceptar'
        );
      })
  }

  public getDiscount(): void {
    this.shoppingCartService.getDiscount(this.cartData.id).subscribe(
      (data) => {
        this.promotionDiscount = data;
        this.loadCard = true;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener el carrito de compras.',
          'Aceptar'
        );
      })
  }

  public getShoppingCartByUserId(): void {
    if (this.userId != null) {
      this.shoppingCartService.getShoppingCartByUserId(parseInt(this.userId, 10)).subscribe(
        (data) => {
          this.cartData = data[0];
          this.subTotalPrice = data[0].products.reduce((total: any, product: any) => total + product.price, 0);
          this.getTotal();
        },
        (error) => {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo obtener el carrito de compras.',
            'Aceptar'
          );
        })
    }
  }

  public removeProductToCart(product: ProductInCart): void {
    this.shoppingCartService.removeProductToCart(this.cartData.id, product.id).subscribe(
      (response) => {
        this.snackBarService.successMessage(
          'Se ha eliminado el producto al carrito.',
          'Aceptar'
        );
        this.getShoppingCartByUserId();
      },
      (error) => {
        if (error.status == 200) {
          this.snackBarService.successMessage(
            'Se ha eliminado el producto al carrito.',
            'Aceptar'
          );
          this.getShoppingCartByUserId();

        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo eliminar el producto al carrito.',
            'Aceptar'
          );
        }
      })
  }

  public makeSale(): void {

    this.shoppingCartService.makeSale(this.cartData.id, this.paymentSelected.id).subscribe(
      (response) => {
        this.snackBarService.successMessage(
          'Se ha finalizado la compra',
          'Aceptar'
        );
        this.promoApply = response.promotionApplied;
        this.discount = response.discount;
        this.totalPrice = response.totalPrice;
        localStorage.removeItem('shoppingCartId')
      },
      (error) => {
        if (error.status == 200) {
          this.snackBarService.successMessage(
            'Se ha eliminado el producto al carrito.',
            'Aceptar'
          );
          localStorage.removeItem('shoppingCartId')
        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo eliminar el producto al carrito.',
            'Aceptar'
          );
        }
      })

  }
}
