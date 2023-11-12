import { Component } from '@angular/core';
import { operation_crud } from 'src/app/constants/generic-values';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent {
  operation_register = operation_crud.register;

}
