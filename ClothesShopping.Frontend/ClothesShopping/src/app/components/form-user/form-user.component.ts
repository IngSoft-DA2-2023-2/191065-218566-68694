import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { RoleResponse } from 'src/app/models/role-models/role-response';
import { UserRequest } from 'src/app/models/user-models/user-request';
import { UserResponse } from 'src/app/models/user-models/user-response';
import { RoleService } from 'src/app/services/role.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { UserService } from 'src/app/services/user-service';

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.css']
})
export class FormUserComponent implements OnInit {
  roles: RoleResponse[] = new Array<RoleResponse>();
  userForm: FormGroup;
  user: UserResponse = new UserResponse();
  @Input() parentUserManagementComponent: any;

  constructor(
    private roleService: RoleService,
    public snackBarService: SnackBarService,
    private userService: UserService,
    public dialog: MatDialog,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.userForm = this.fb.group({
      email: [this.user.email || '', [Validators.required, Validators.email]],
      password: [this.user.password || '', Validators.required],
      address: [this.user.address || '', Validators.required],
      selectedRoles: [this.user.roles || [], Validators.required],
    });
  }

  ngOnInit() {
    this.getRoles();
  }
  public getRoles(): void {
    this.roleService.getAll().subscribe(
      (response) => {
        this.roles = response as RoleResponse[];
        console.log(this.roles)
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de roles.',
          'Accept'
        );
      }
    );
  }
  public save(): void {
    const formValues = this.userForm.value;

    // Estructurar un objeto UserRequest
    const userRequest: UserRequest = {
      email: formValues.email,
      password: formValues.password,
      address: formValues.address,
      roles: formValues.selectedRoles.map((role: RoleResponse) => role.name)
    };
    this.userService.add(userRequest).subscribe(
      () => {
        this.snackBarService.successMessage(
          'El usuario fue ingresado correctamente.',
          'Aceptar'
        );
        this.parentUserManagementComponent.getUsers();
        this.userForm.reset();
        this.dialog.closeAll();
      },
      (error) => {
        console.log(error);
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo agregar el usuario.',
          'Aceptar'
        );
      })
  }
}
