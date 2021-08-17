import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //email!: string;
  //password!: string;
  //constructor() { }
  //login() {
  //  console.log(this.email);
  //  console.log(this.password);
  //}
  //ngOnInit(): void {
  //}
    form = this.fb.group({
        email: ['',{
          validators:[Validators.required, Validators.email,Validators.minLength(5)],
          updateOn: 'blur'
        }],
        password: ['',[Validators.required, Validators.minLength(8),
          createPasswordStrengthValidator()]]
    });
    constructor(private fb: FormBuilder){}
    ngOnInit(){}
    get email(){return this.form.get('email');}
    get password(){return this.form.get('password');}
}
export function createPasswordStrengthValidator(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {

      const value = control.value;

      if (!value) {
          return null;
      }

      const hasUpperCase = /[A-Z]+/.test(value);

      const hasLowerCase = /[a-z]+/.test(value);

      const hasNumeric = /[0-9]+/.test(value);

      const passwordValid = hasUpperCase && hasLowerCase && hasNumeric;

      return !passwordValid ? {passwordStrength:true}: null;
  }
}
