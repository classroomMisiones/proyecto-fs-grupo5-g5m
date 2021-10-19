import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { LoginRequestService } from '../service/login-request.service';
import { NTokenService } from '../service/n-token.service';
import { LoginLoginRequestService } from '../service/login-usuarios.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  form = this.fb.group({
    Mail : ['sophiagonazalez@hotmail.com',{ validators:[Validators.required, Validators.email,Validators.minLength(5)], updateOn: 'blur' }],
    Clave : ['Password55',[Validators.required, Validators.minLength(8), createPasswordStrengthValidator() ]]
  });
  // Objeto para el envio de la solicitud de tocken
  grabarToken = {
    "Mail" : "",
    "Clave" : "",
    "N_token" : ""
  }
  controlProcesos : boolean = false;

  constructor(private fb : FormBuilder, 
              private loginRequestService : LoginRequestService, 
              private nTokenService : NTokenService,
              private loginLoginRequestService : LoginLoginRequestService, 
              private router : Router)
  { }
  
  get Mail(){return this.form.get('Mail');}
  get Clave(){return this.form.get('Clave');}

  // ***************************************
  // ***** HAGO EL SUBMIT DE LOS DATOS *****
  onSubmit(){
    // ********* VERIFICO SI EL SERVIDOR RESPONDE
    console.log('HAGO EL PING')
    if (this.loginRequestService.getPing()){          console.log('OK; HAGO EL PEDIDO DEL TOKEN')
        
        this.loginRequestService.postToken(this.form.value)
        .then(token =>{
            //console.log("Token recibido"+ token);
            console.log('OK; GUARDO EN EL LOCAL STORAGE')
            localStorage.setItem('miToken', token);
            // ***** coloco la bandera de control en true
            this.controlProcesos = true;
            // ***** paso todos los valorres al objeto a anviar
            this.grabarToken = this.form.value;
            this.grabarToken.N_token = token;
        //************************************************************************************* */
            // ********** GUARGO EL LOGIN EN LA TABLA "login_usuarios" EN LA BBDD ***************************************            
            if (this.controlProcesos){
              console.log("VOY A GRABAR EL LOGIN DEL USUARIO EN LA BBDD")
              console.log(this.grabarToken);
              this.loginLoginRequestService.postLoginUsuario(this.grabarToken)
              .then(respuesta =>{
                  console.log("Login grabado en la BBDD");
                  //************************************************************************************* */
                  console.log('OK; A ENTRAR GRABAR EL TOKEN EN BBDD')
                  // ********** SI RECIBI EL TOKENN LO GUARGO EN LA BBDD ***************************************
                  if (this.controlProcesos){
                      console.log("OK, VOY A GRABAR EL TOKEN EN LA BBDD")
                      console.log(this.grabarToken);
                      this.nTokenService.PutToken(this.grabarToken)
                      .then(() =>{
                          console.log("Token grabado en la BBDD");
                          this.router.navigate(['/dashboard']);
                      })
                      .catch(error => {
                          console.log("NO SE PUDO GRABAR EL TOKEN ERROR: " + error)
                          this.controlProcesos = false;
                      });          
                  }
                  //************************************************************************************* */
              })
              .catch(error => console.log("NO SE PUDO GRABAR EL LOGIN USUARIO ERROR: " + error)
              );
            }
        //************************************************************************************* */
        })
        .catch(error => {
            console.log("ERROR AL OBTRENER EL TOKEN" + error)
            this.controlProcesos = false;
        });
    }else{
      console.log("NO HAY CONEXION CON EL SERVIDOR")
    }
  };

  ngOnInit(){}
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
