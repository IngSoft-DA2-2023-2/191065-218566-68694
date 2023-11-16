import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { operation_crud, pagination_default, pagination_options } from 'src/app/constants/generic-values';
import { BrandResponse } from 'src/app/models/brand-models/brand-response';
import { CategoryResponse } from 'src/app/models/category-models/category-response';
import { ColorResponse } from 'src/app/models/color-models/color-response';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { BrandService } from 'src/app/services/brand.service';
import { CategoryService } from 'src/app/services/category.service';
import { ColorService } from 'src/app/services/color.service';
import { ProductService } from 'src/app/services/product.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-products-admin',
  templateUrl: './products-admin.component.html',
  styleUrls: ['./products-admin.component.css']
})
export class ProductsAdminComponent {
  displayedColumns: string[] = [
    'name',
    'price',
    'description',
    'brand',
    'category',
    'colors',
    'stock',
    'promoAvailable',
    'actions'
  ];
  productResponse: ProductResponse = new ProductResponse();
  products: ProductResponse[] = new Array<ProductResponse>();
  categories: CategoryResponse[] = new Array<CategoryResponse>();
  brands: BrandResponse[] = new Array<BrandResponse>();
  colors: ColorResponse[] = new Array<CategoryResponse>();
  paginationDefault = pagination_default;
  paginationOps = pagination_options;
  paginatorLength: number = 0;
  productsTable = new MatTableDataSource<ProductResponse>(this.products);
  operation_edit = operation_crud.update;
  operation_add = operation_crud.create;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild('modalFormAddProduct', { static: false })
  modalFormAddProduct!: TemplateRef<any>;
  constructor(
    private productService: ProductService,
    private colorService: ColorService,
    private brandService: BrandService,
    private categoryService: CategoryService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initPagination();
    this.getProducts();
    this.getBrands();
    this.getColors();
    this.getCategories();

  }

  private initPagination(): void {
    this.productsTable = new MatTableDataSource<ProductResponse>();
    this.productsTable.paginator = this.paginator;
    this.productsTable.sort = this.sort;
  }

  public getProducts(): void {
    this.productService.getAll().subscribe(
      (response) => {
        this.products = response as ProductResponse[];
        this.productsTable = new MatTableDataSource<ProductResponse>(response);
        this.productsTable.paginator = this.paginator;
        this.productsTable.sort = this.sort;
        this.paginatorLength = this.products.length;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de productos.',
          'Accept'
        );
      }
    );
  }

  private getCategories(): void {
    this.categoryService.getAll().subscribe(
      (response) => {
        this.categories = response as CategoryResponse[];
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de categorias.',
          'Accept'
        );
      }
    );
  }

  private getColors(): void {
    this.colorService.getAll().subscribe(
      (response) => {
        this.colors = response as ColorResponse[];
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de categorias.',
          'Accept'
        );
      }
    );
  }

  private getBrands(): void {
    this.brandService.getAll().subscribe(
      (response) => {
        this.brands = response as BrandResponse[];
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de marcas.',
          'Accept'
        );
      }
    );
  }

  public openModalAddProduct(): void {
    this.dialog.open(this.modalFormAddProduct);
  }

  public applyFilter(event: any): void {
    let filterValue = event.target.value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.productsTable.filter = filterValue;
  }

}
