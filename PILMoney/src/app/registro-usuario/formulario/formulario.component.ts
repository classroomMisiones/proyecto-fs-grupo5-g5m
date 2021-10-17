import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';
@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {
  //private emailPattern: any = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  //createRegistro: FormGroup;
  form = this.fb.group({
    email: ['',{
      validators:[Validators.required, Validators.email,Validators.minLength(5)],
      updateOn: 'blur'
    }],
    password: ['',[Validators.required, Validators.minLength(8),
      createPasswordStrengthValidator()]],
    nombre: ['',[Validators.required, Validators.minLength(8),
      createPasswordStrengthValidator()]],
    apellido: ['',[Validators.required, Validators.minLength(8),
      createPasswordStrengthValidator()]]
});


constructor(private fb: FormBuilder){}
ngOnInit(){}
get email(){return this.form.get('email');}
get password(){return this.form.get('password');}
get nombre(){return this.form.get('nombre');}
get apellido(){return this.form.get('apellido');}

  // **** ENVIO EL FORMULARIO PARA EL POST
  onSubmit(){

  }

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
