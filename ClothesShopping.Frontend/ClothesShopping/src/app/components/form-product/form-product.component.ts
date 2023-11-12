import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BrandResponse } from 'src/app/models/brand-models/brand-response';
import { CategoryResponse } from 'src/app/models/category-models/category-response';
import { ColorResponse } from 'src/app/models/color-models/color-response';
import { ProductResponse } from 'src/app/models/product-models/product-response';
import { BrandService } from 'src/app/services/brand.service';
import { CategoryService } from 'src/app/services/category.service';
import { ColorService } from 'src/app/services/color.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {
  productForm: FormGroup;
  brands: BrandResponse[] = new Array<BrandResponse>();
  //colors: ColorResponse[] = new Array<ColorResponse>();
  categories: CategoryResponse[] = new Array<CategoryResponse>();
  colors = [{ id: 1, name: 'Blanco' }];

  constructor(private fb: FormBuilder, private brandService: BrandService,
    private colorService: ColorService,
    private categoryService: CategoryService,
    public snackBarService: SnackBarService) {
      this.productForm = this.fb.group({
        name: ['', Validators.required],
        price: [0, Validators.min(0)],
        description: [''],
        brandId: [null],
        categoryId: [null],
        stock: [0, Validators.min(0)],
        promoAvailable: [false],
        colors: [[]]
      });
  }

  ngOnInit() {
    this.getBrands();
    this.getCategories();
   // this.getColors(); 

   }
  onSubmit() {
    if (this.productForm.valid) {
      // Obtiene los valores del formulario, incluidos los IDs de marca, categoría y colores.
      const productData = this.productForm.value;
      console.log(productData); // Aquí puedes enviar los datos al servicio para guardarlos.

      // Reinicia el formulario o realiza otras acciones según tus necesidades.
      this.productForm.reset();
    }
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

  /*public getColors(): void {
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
  }*/

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
  }}

