import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PromotionRequest } from 'src/app/models/promotion-models/promotion-request';
import { PromotionResponse } from 'src/app/models/promotion-models/promotion-response';
import { PromotionService } from 'src/app/services/promotion.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-form-promotion',
  templateUrl: './form-promotion.component.html',
  styleUrls: ['./form-promotion.component.css']
})
export class FormPromotionComponent {
  promotionForm: FormGroup;
  promotion: PromotionResponse = new PromotionResponse();
  @Input() promotionParentComponent: any;

  constructor(
    private promotionService: PromotionService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
    private fb: FormBuilder
  ) {
    this.promotionForm = this.fb.group({
      name: new FormControl(this.promotion.name || ''),
      description: new FormControl(this.promotion.description || ''),
    });
    this.promotionForm.valueChanges.subscribe((formValues) => {
      this.promotion = { ...this.promotion, ...formValues };
    });
  }

  public save(): void {
    const promotionRequest = new PromotionRequest();
    promotionRequest.name = this.promotion.name;
    promotionRequest.description = this.promotion.description;
    this.promotionService.add(promotionRequest).subscribe(
      () => {
        this.snackBarService.successMessage(
          'La promoción fue ingresado correctamente.',
          'Aceptar'
        );
        this.promotionParentComponent.getPromotions();
        this.closeModal();
      },
      (error) => {
        console.log(error);
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo agregar la promoción.',
          'Aceptar'
        );
      }
    );
  }

  public closeModal(): void {
    this.dialog.closeAll();
    this.promotionForm.reset();
  }

}
