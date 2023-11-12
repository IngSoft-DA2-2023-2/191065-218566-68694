import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { operation_crud, pagination_default, pagination_options } from 'src/app/constants/generic-values';
import { UserResponse } from 'src/app/models/user-models/user-response';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { UserService } from 'src/app/services/user-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  displayedColumns: string[] = [
    'email',
    'password',
    'address',
    'roles',
    'actions',
  ];
  userResponseSelected: UserResponse = new UserResponse();
  users: UserResponse[] = new Array<UserResponse>();
  paginationDefault = pagination_default;
  paginationOps = pagination_options;
  paginatorLength: number = 0;
  usersTable = new MatTableDataSource<UserResponse>(this.users);
  operation_edit = operation_crud.update;
  operation_add = operation_crud.create;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild('modalConfirmDeleteUser', { static: false })
  modalConfirmDeleteUser!: TemplateRef<any>;
  @ViewChild('modalFormAddUser', { static: false })
  modalFormAddUser!: TemplateRef<any>;
  @ViewChild('modalFormUserEdit', { static: false })
  modalFormUserEdit!: TemplateRef<any>;
  rolUser = localStorage.getItem('rolUser');
  constructor(
    private userService: UserService,
    public snackBarService: SnackBarService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initPagination();
    this.getUsers();
  }

  private initPagination(): void {
    this.usersTable = new MatTableDataSource<UserResponse>();
    this.usersTable.paginator = this.paginator;
    this.usersTable.sort = this.sort;
  }

  public applyFilter(event: any): void {
    let filterValue = event.target.value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.usersTable.filter = filterValue;
  }


  public getUsers(): void {
    this.userService.getAll().subscribe(
      (response) => {
        this.users = response as UserResponse[];
        this.usersTable = new MatTableDataSource<UserResponse>(response);
        this.usersTable.paginator = this.paginator;
        this.usersTable.sort = this.sort;
        this.paginatorLength = this.users.length;
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo obtener la lista de usuarios.',
          'Accept'
        );
      }
    );
  }
  openModalConfirmDeleteUser(user: UserResponse): void {
    this.userResponseSelected = user;
    this.dialog.open(this.modalConfirmDeleteUser);
  }

  openModalAddUser(): void {
    this.dialog.open(this.modalFormAddUser);
  }

  openModalEditUser(user: UserResponse): void {
    this.userResponseSelected = user;
    this.dialog.open(this.modalFormUserEdit);
  }

  deleteUser() {
    this.userService.delete(this.userResponseSelected.id).subscribe(
      (response) => {
        this.getUsers();
        this.snackBarService.successMessage(
          'El usuario ha sido eliminado correctamente',
          'Aceptar'
        );
        this.dialog.closeAll();
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error y no se pudo eliminar el usuario.',
          'Aceptar'
        );
      }
    );
  }
}
