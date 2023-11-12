import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { RoleResponse } from 'src/app/models/role-models/role-response';
import { UserResponse } from 'src/app/models/user-models/user-response';
import { RoleService } from 'src/app/services/role.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.css']
})
export class FormUserComponent implements OnInit {
  roles: RoleResponse[] = new Array<RoleResponse>();
  userForm: FormGroup;
  user: UserResponse = new UserResponse();

  constructor(
    private roleService: RoleService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.userForm = this.fb.group({
      email: new FormControl(this.user.email || ''),
      password: new FormControl(this.user.password || ''),
      address: new FormControl(this.user.address || ''),
      selectedRoles: new FormControl(this.user.roles || []), // Usar el objeto de roles completo
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
}
