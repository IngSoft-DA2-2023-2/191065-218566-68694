import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { operation_crud } from 'src/app/constants/generic-values';
import { RoleResponse } from 'src/app/models/role-models/role-response';
import { UserRequest } from 'src/app/models/user-models/user-request';
import { UserResponse } from 'src/app/models/user-models/user-response';
import { UserUpdate } from 'src/app/models/user-models/user-update';
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
  @Input() user: UserResponse = new UserResponse();
  @Input() parentUserManagementComponent: any;
  @Input() operation = '';
  operation_edit = operation_crud.update;
  operation_add = operation_crud.create;
  operation_register = operation_crud.register;
  rolesValidator: any;
  constructor(
    private roleService: RoleService,
    public snackBarService: SnackBarService,
    private userService: UserService,
    public dialog: MatDialog,
    private router: Router,
    private fb: FormBuilder
  ) {
    if (this.operation !== this.operation_register) {
      this.rolesValidator = Validators.required;
    }
    this.userForm = this.fb.group({
      email: [this.user.email || '', [Validators.required, Validators.email]],
      password: [this.user.password || '', Validators.required],
      address: [this.user.address || '', Validators.required],
      selectedRoles: [this.user.roles || [], this.rolesValidator],
    });
  }

  ngOnInit() {
    this.getRoles();
    this.initForm();
  }

  private initForm(): void {
    this.userForm = this.fb.group({
      email: [this.user.email || '', [Validators.required, Validators.email]],
      password: [this.user.password || '', Validators.required],
      address: [this.user.address || '', Validators.required],
      selectedRoles: [this.user.roles.map(role => role.id) || []],
    });

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
    const formValues = this.userForm?.value;
    const selectedRoleIds: number[] = this.userForm.value.selectedRoles; // Obtener los IDs seleccionados del formulario
    let selectedRoles: RoleResponse[] = this.roles.filter(role => selectedRoleIds.includes(role.id));
    const clientRoles: RoleResponse[] = this.roles.filter(role => role.name === "Client");
    const roles = this.operation === this.operation_register ?
      clientRoles.map(role => role.name) :
      selectedRoles.map(role => role.name);

      const userRequest: UserRequest = {
      email: formValues.email,
      password: formValues.password,
      address: formValues.address,
      roles: roles
    };
    this.userService.add(userRequest).subscribe(
      () => {
        this.snackBarService.successMessage(
          'El usuario fue ingresado correctamente.',
          'Aceptar'
        );
        this.parentUserManagementComponent.getUsers();
        this.userForm?.reset();
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

  public update(): void {
    const formValues = this.userForm?.value;
    const selectedRoleIds: number[] = this.userForm.value.selectedRoles; // Obtener los IDs seleccionados del formulario
    const selectedRoles: RoleResponse[] = this.roles.filter(role => selectedRoleIds.includes(role.id));
    const userUpdate: UserUpdate = {
      id: this.user.id,
      email: formValues.email,
      password: formValues.password,
      address: formValues.address,
      roles: selectedRoles.map((role: RoleResponse) => role.name)
    };

    this.userService.updateUser(userUpdate).subscribe(
      () => {
        this.snackBarService.successMessage(
          'El usuario fue actualizado correctamente.',
          'Aceptar'
        );
        this.parentUserManagementComponent.getUsers();
        this.userForm?.reset();
        this.dialog.closeAll();
      },
      (error) => {
        if (error.status == 200) {
          this.parentUserManagementComponent.getUsers();
          this.userForm?.reset();
          this.dialog.closeAll();
          this.snackBarService.successMessage(
            'El usuario fue actualizado correctamente.',
            'Aceptar'
          );
        } else {
          this.snackBarService.errorMessage(
            'Ocurrio un error y no se pudo habilitar la promoción.',
            'Aceptar'
          );
        }
      })
  }
}
