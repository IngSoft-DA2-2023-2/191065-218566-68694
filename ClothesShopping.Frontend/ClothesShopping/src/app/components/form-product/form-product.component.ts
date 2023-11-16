import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { BrandResponse } from 'src/app/models/brand-models/brand-response';
import { CategoryResponse } from 'src/app/models/category-models/category-response';
import { ColorResponse } from 'src/app/models/color-models/color-response';
import { ProductRequest } from 'src/app/models/product-models/product-request';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { BrandService } from 'src/app/services/brand.service';
import { CategoryService } from 'src/app/services/category.service';
import { ColorService } from 'src/app/services/color.service';
import { ProductService } from 'src/app/services/product.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {
  productForm: FormGroup;
  brands: BrandResponse[] = new Array<BrandResponse>();
  colors: ColorResponse[] = new Array<ColorResponse>();
  categories: CategoryResponse[] = new Array<CategoryResponse>();
  product: ProductResponse = new ProductResponse()
  @Input() parentProductsAdminComponent: any;
  promoAvailable: boolean = false;
  operation: string = '';
  constructor(private fb: FormBuilder, private brandService: BrandService,
    private colorService: ColorService,
    private categoryService: CategoryService,
    private productService: ProductService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog) {
    this.productForm = this.fb.group({
      name: [this.product.name || '', Validators.required],
      price: [this.product.price || 0, Validators.min(0)],
      description: [this.product.description || '', Validators.required],
      brand: [this.product.brand || null, Validators.required],
      category: [this.product.category || null, Validators.required],
      stock: [this.product.stock || 0, Validators.min(0)],
      promoAvailable: [this.product.promoAvailable || true, Validators.required],
      colors: [this.product.colors || [], Validators.required]
    });
    this.promoAvailable = this.product.promoAvailable;
  }

  ngOnInit() {
    this.getBrands();
    this.getCategories();
    this.getColors();
    this.initForm();
  }

  private initForm(): void {
    this.productForm = this.fb.group({
      name: [this.product.name || '', Validators.required],
      price: [this.product.price || 0, Validators.min(0)],
      description: [this.product.description || '', Validators.required],
      brand: [this.product.brand || null, Validators.required],
      category: [this.product.category || null, Validators.required],
      stock: [this.product.stock || 0, Validators.min(0)],
      promoAvailable: [this.product.promoAvailable || true, Validators.required],
      colors: [this.product.colors.map(color => color.id) || []],
    });
    this.promoAvailable = this.product.promoAvailable;
  }

  public togglePromoAvailable(): void {
    this.promoAvailable = !this.promoAvailable;
  }

  onSubmit() {
    const formValues = this.productForm?.value;
    const selectedColorIds: number[] = this.productForm.value.colors; // Obtener los IDs seleccionados del formulario
    const productRequest: ProductRequest = {
      name: formValues.name,
      price: formValues.price,
      description: formValues.description,
      category: formValues.category,
      brand: formValues.brand,
      colors: selectedColorIds,
      stock: formValues.stock,
      promoAvailable: this.promoAvailable,
    };
    this.productService.add(productRequest).subscribe(
      (response) => {
        this.productForm.reset();
        this.dialog.closeAll();
        this.snackBarService.successMessage(
          'Se agrego el producto exitosamente.',
          'Accept'
        );
        this.parentProductsAdminComponent.getProducts();

      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de marcas.',
          'Accept'
        );
      }
    );
    /*if (this.productForm.valid) {
      // Obtiene los valores del formulario, incluidos los IDs de marca, categoría y colores.
      const productData = this.productForm.value;
      console.log(productData); // Aquí puedes enviar los datos al servicio para guardarlos.

      // Reinicia el formulario o realiza otras acciones según tus necesidades.
      this.productForm.reset();
    }*/
  }

  public getBrands(): void {
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

  public getColors(): void {
    this.colorService.getAll().subscribe(
      (response) => {
        this.colors = response as ColorResponse[];
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de colores.',
          'Accept'
        );
      }
    );
  }

  public getCategories(): void {
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
}

