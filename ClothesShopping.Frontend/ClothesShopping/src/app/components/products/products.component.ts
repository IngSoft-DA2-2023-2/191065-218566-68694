// products.component.ts
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { ProductService } from 'src/app/services/product.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  productSelected: ProductResponse = new ProductResponse();
  products: ProductResponse[] = new Array<ProductResponse>();
  filteredProducts: ProductResponse[] = new Array<ProductResponse>();
  @ViewChild('modalFormProductDetail', { static: false })
  modalFormProductDetail!: TemplateRef<any>;
  @ViewChild('modalRequestLogin', { static: false })
  modalRequestLogin!: TemplateRef<any>;
  searchTerm: string = '';

  pageSize = 8;
  currentPage = 0;
  constructor(
    public productService: ProductService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
  ) {
  }

  ngOnInit(): void {
    this.getProducts()
  }


  public getProducts(): void {
    this.productService.getAll().subscribe(
      (response) => {
        this.products = response as ProductResponse[];
        this.filteredProducts = this.products;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de usuarios.',
          'Accept'
        );
      }
    );
  }


  public onPageChange(event: any): void {
    this.currentPage = event.pageIndex;
  }

  public openModalProductDetail(product: ProductResponse): void {
    this.productSelected = product;
    this.dialog.open(this.modalFormProductDetail);
  }
  public getRequestLoginUser(message: string): void {
    if (message == 'request-login-user') {
      this.dialog.closeAll();
      this.dialog.open(this.modalRequestLogin);
    }
  }

  public applyFilter(): void {
    const filterValue = this.searchTerm.toLowerCase();
    this.filteredProducts = this.products.filter((product) => {
      return (
        product.name.toLowerCase().includes(filterValue) ||
        product.description.toLowerCase().includes(filterValue) ||
        product.brand.name.toLowerCase().includes(filterValue) ||
        product.category.name.toLowerCase().includes(filterValue)
        // Agrega más propiedades de productos según tus necesidades
      );
    });
  }
}
