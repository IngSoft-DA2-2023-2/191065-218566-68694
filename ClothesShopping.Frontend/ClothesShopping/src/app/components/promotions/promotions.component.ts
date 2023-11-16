import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { operation_crud, pagination_default, pagination_options } from 'src/app/constants/generic-values';
import { PromotionResponse } from 'src/app/models/promotion-models/promotion-response';
import { PromotionService } from 'src/app/services/promotion.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.css']
})
export class PromotionsComponent implements OnInit {

  displayedColumns: string[] = [
    'name',
    'description',
    'available'
  ];
  promotionResponse: PromotionResponse = new PromotionResponse();
  promotions: PromotionResponse[] = new Array<PromotionResponse>();
  paginationDefault = pagination_default;
  paginationOps = pagination_options;
  paginatorLength: number = 0;
  promotionsTable = new MatTableDataSource<PromotionResponse>(this.promotions);
  operation_edit = operation_crud.update;
  operation_add = operation_crud.create;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild('modalFormAddPromotion', { static: false })
  modalFormAddPromotion!: TemplateRef<any>;

  constructor(
    private promotionService: PromotionService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
  ) { }


  ngOnInit(): void {
    this.initPagination();
    this.getPromotions();
  }

  private initPagination(): void {
    this.promotionsTable = new MatTableDataSource<PromotionResponse>();
    this.promotionsTable.paginator = this.paginator;
    this.promotionsTable.sort = this.sort;
  }

  public applyFilter(event: any): void {
    let filterValue = event.target.value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.promotionsTable.filter = filterValue;
  }

  public getPromotions(): void {
    this.promotionService.getAll().subscribe(
      (response) => {
        this.promotions = response as PromotionResponse[];
        this.promotionsTable = new MatTableDataSource<PromotionResponse>(response);
        this.promotionsTable.paginator = this.paginator;
        this.promotionsTable.sort = this.sort;
        this.paginatorLength = this.promotions.length;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de promociones.',
          'Accept'
        );
      }
    );
  }

  openModalAddUser(): void {
    this.dialog.open(this.modalFormAddPromotion);
  }

  uploadFile(event: Event) {
    const element = event.currentTarget as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if (fileList) {
      console.log("FileUpload -> files", fileList);
    }
}

  public togglePromotionEnablement(promotion: PromotionResponse): void {
    if (promotion.available) {
      this.deactivePromotion(promotion);
    }
    else {
      this.activePromotion(promotion);
    }
  }

  private activePromotion(promotion: PromotionResponse): void {
    this.promotionService.activePromotion(promotion.id).subscribe(
      (response) => {
        this.getPromotions();
        this.snackBarService.successMessage(
          'Se ha activado la promoción',
          'Aceptar'
        );
      },
      (error) => {
        if (error.status == 200) {
          this.getPromotions();
          this.snackBarService.successMessage(
            'La promoción ha sido habilitada',
            'Aceptar'
          );
        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo habilitar la promoción.',
            'Aceptar'
          );
        }

      }
    );
  }

  private deactivePromotion(promotion: PromotionResponse): void {
    this.promotionService.deactivePromotion(promotion.id).subscribe(
      (response) => {
        this.getPromotions();
        this.snackBarService.errorMessage(
          'La solicitud se completó, pero la respuesta no fue reconocida.',
          'Aceptar'
        );

      },
      (error) => {
        if (error.status == 200) {
          this.getPromotions();
          this.snackBarService.successMessage(
            'La promoción ha sido deshabilitada',
            'Aceptar'
          );
        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo deshabilitar la promoción.',
            'Aceptar'
          );
        }

      }
    );
  }
}
