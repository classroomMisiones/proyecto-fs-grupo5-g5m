import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';

@Component({
  selector: 'app-ingresar-dinero',
  templateUrl: './ingresar-dinero.component.html',
  styleUrls: ['./ingresar-dinero.component.css']
})
export class IngresarDineroComponent implements OnInit {
  form = this.fb.group({
    monto: ['',[Validators.required, Validators.minLength(8),
      createStrengthValidator()]],
    tarjeta: ['',[Validators.required, Validators.minLength(8),
        createStrengthValidator()]],

  });
  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
  }
  get monto(){return this.form.get('monto');}
  get tarjeta(){return this.form.get('tarjeta');}

}
// esta funcion es del pasword pero se modifico para que pueda controlar el campo numeric
export function createStrengthValidator(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {

      const value = control.value;

      if (!value) {
          return null;
      }

      const hasNumeric = /[0-9]+/.test(value);

      const passwordValid = hasNumeric;

      return !passwordValid ? {passwordStrength:true}: null;
  }
}
