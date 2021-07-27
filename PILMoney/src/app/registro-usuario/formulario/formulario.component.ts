import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {
  private emailPattern: any = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  createRegistro: FormGroup;
  submitted = false;
  constructor(private fb: FormBuilder
        ) {
          this.createRegistro=this.fb.group({
            nombre:['',Validators.required],
            apellido:['',Validators.required],
            email: new FormControl('', [Validators.required, Validators.minLength(5), Validators.pattern(this.emailPattern)]),
            dni:['',Validators.required],
            telefono:['',Validators.required],
            password:['',Validators.required],
          })
        }

  ngOnInit(): void {
  }
  registrarse(){
    this.submitted = true;
    if(this.createRegistro.invalid){
      return;
    }
  }
}
