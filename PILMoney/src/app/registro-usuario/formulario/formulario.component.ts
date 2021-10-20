import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Registro } from '../../Interfaces/registro.interface';
import { loginInterface } from '../../Interfaces/login.interface';
import { N_token } from '../../Interfaces/N_token.interface';


import { UsuariosService } from 'src/app/service/usuarios.service';
import { EmailService } from 'src/app/service/email.service';
import { LoginLoginRequestService } from '../../service/login-usuarios.service';
import { LoginRequestService } from '../../service/login-request.service';
import { NTokenService } from '../../service/n-token.service';
import { UsuarioCrearCuentaService } from '../../service/usuario-crear-cuenta.service';
import { MailCrearCuentaService } from '../../service/mail-crear-cuenta.service';


import { Email } from '../../Modelos/email.model';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {
  //private emailPattern: any = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  //createRegistro: FormGroup;
  form = this.fb.group({
    Nombre: ['Antonio',[Validators.required, Validators.minLength(8), createPasswordStrengthValidator()]],
    Apellido: ['Valle',[Validators.required, Validators.minLength(8), createPasswordStrengthValidator()]],
    Mail: ['antoniovalle@gmail.com',{ validators:[Validators.required, Validators.email,Validators.minLength(5)], updateOn: 'blur' }],
    Clave: ['Password56',[Validators.required, Validators.minLength(8), createPasswordStrengthValidator()]],
    Clave2: ['Password56',[Validators.required, Validators.minLength(8), createPasswordStrengthValidator()]]

  });
   // Objeto para el envio de la solicitud de tocken
  objpidoToken! : loginInterface; // objeto para pedir el token => "Mail" "Clave"
  objGrabarToken! : N_token; // objeto para guardar el token => "Mail" "Clave" "N_token"

  ObjMail = new Email();
  controlProcesos : boolean = false;

  //*** creo un objeto para tomar los valores enviados por el formulario
  ObjBusqueda = {
    "Nombre" : "",
    "Apellido" : "",
    "Mail" : "",
    "Clave" : "",
    "Clave2" : "",
    "Id_rol" : 1,
    "Id_usuario" : 0,
    "Id_email" : 0
  }

  constructor(private fb : FormBuilder,
              private usuariosService : UsuariosService,
              private router : Router,
              private emailService : EmailService,
              private loginLoginRequestService : LoginLoginRequestService,
              private loginRequestService : LoginRequestService,
              private nTokenService : NTokenService,
              private usuarioCrearCuentaService : UsuarioCrearCuentaService,
              private mailCrearCuentaService : MailCrearCuentaService
              ){}

  ngOnInit(){

  }

  get nombre(){return this.form.get('Nombre');}
  get apellido(){return this.form.get('Apellido');}
  get email(){return this.form.get('Mail');}
  get clave(){return this.form.get('Clave');}
  get clave2(){return this.form.get('Clave');}

  // ****************************************************
  // ********* ENVIO EL FORMULARIO PARA EL POST *********
  // ****************************************************
  onSubmit(){ //this.router.navigate(['/dashboard']);
      // ***** HAGO EL SUBMIT DE LOS DATOS *****
      // ***asigno los valores del formulario al objeto
      this.ObjBusqueda = this.form.value;
      this.ObjMail = this.ObjBusqueda;
      this.ObjBusqueda.Id_rol = 1;
      this.objpidoToken = this.form.value;          // console.log(this.ObjBusqueda+" "+this.objGrabarToken+" "+this.objpidoToken);

      console.log('HAGO EL PING');
      if (this.loginRequestService.getPing()){      // console.log("OK, PING RECIBIDO");
        // ********** GUARDO EL MAIL **********
        this.emailService.postMail(this.ObjBusqueda)
        .then(IdMail =>{
          console.log("Registro de Email Exitoso!");
          this.ObjBusqueda.Id_usuario = IdMail;
          console.log(IdMail);

              // // ********** Busco el Id_mail **********
              // this.mailCrearCuentaService.getId()
              // .then(idmail =>{
              //     console.log(`Obtengo el Id mail : ${idmail}`);
                  this.ObjMail.Id_email = IdMail;
                  this.ObjBusqueda.Id_email = IdMail;
              //     console.log(this.ObjBusqueda);
                      // ********** GUARDO EL USUARIO **********
                      this.usuariosService.postUsuario(this.ObjBusqueda)
                      .then(IdUsuario =>{
                          console.log("Registro de Usuario Exitoso!");
                          // ********** Busco el Id_usuario **********
                              // this.usuarioCrearCuentaService.getId()
                              // .then(idusuario =>{
                              //     console.log(`Obtengo el Id usuario : ${idusuario}`);
                                  this.ObjMail.Id_usuario = IdUsuario;
                                      // ********** Actualizo el mail **********
                                      this.emailService.putMail(IdMail, this.ObjMail)
                                      .then(() =>{
                                          console.log("Actualizacion del MAil Exitosa!");
                                       //*************** HAGO EL PEDIDO DEL TOKEN ******************* */
                                              console.log('OK; HAGO EL PEDIDO DEL TOKEN')
                                              console.log(this.objpidoToken.Clave+ " "+ this.objpidoToken.Mail)
                                              this.objpidoToken = this.form.value;
                                              this.loginRequestService.postToken(this.objpidoToken)
                                              .then(token =>{
                                                  console.log("Token recibido"+ token);
                                                  localStorage.setItem('miToken', token); // console.log('OK; GUARDO EN EL LOCAL STORAGE')
                                                  //this.controlProcesos = true; // ***** coloco la bandera de control en true
                                                  // ***** paso todos los valorres al objeto a anviar
                                                  this.objGrabarToken = this.form.value;
                                                  this.objGrabarToken.N_token = token;
                                                  console.log(this.objGrabarToken.N_token);
                                                  console.log(this.objGrabarToken.Clave+" "+this.objGrabarToken.Mail);
                                                      // ********** GUARGO EL LOGIN EN LA TABLA "login_usuarios" EN LA BBDD ***************************************
                                                      console.log("VOY A GRABAR EL LOGIN DEL USUARIO EN LA BBDD")
                                                      this.loginLoginRequestService.postLoginUsuario(this.objGrabarToken)
                                                      .then(respuesta =>{
                                                          console.log("Login grabado en la BBDD");
                                                          console.log('OK; A ENTRAR GRABAR EL TOKEN EN BBDD')
                                                          // ********** SI RECIBI EL TOKENN LO GUARGO EN LA BBDD ***************************************
                                                          console.log("OK, VOY A GRABAR EL TOKEN EN LA BBDD")
                                                          console.log(this.objGrabarToken);
                                                              this.nTokenService.PutToken(this.objGrabarToken)
                                                              .then(() =>{
                                                                  console.log("Token grabado en la BBDD");
                                                                  this.router.navigate(['/dashboard']);
                                                              })//grabo token en tabla usuarios
                                                              .catch(error => {
                                                                  console.log("NO SE PUDO GRABAR EL TOKEN ERROR: " + error)
                                                                  this.controlProcesos = false;
                                                              });
                                                      })//login usuario
                                                      .catch(error => console.log("NO SE PUDO GRABAR EL LOGIN USUARIO ERROR: " + error)
                                                      );
                                                })//pedido tokenn
                                                .catch(error => {
                                                    console.log("ERROR AL OBTRENER EL TOKEN" + error)
                                                    this.controlProcesos = false;
                                                });
                                       }) // put mail
                                      .catch(error => {
                                            console.log("No se Pudo Actualizar el MAIL" + error)
                                            this.controlProcesos = false;
                                      });
                                // }) // busco el id usuario
                                // .catch(error => {
                                //     console.log("No se Pudo Obtener el ID" + error)
                                //     this.controlProcesos = false;
                                // });
                      }) // post usuario
                      .catch(error => {
                          console.log("No se Pudo Registrar al Usuario" + error)
                          this.controlProcesos = false;
                      });
                // }) // buscar id
                // .catch(error => {
                //     console.log("No se Pudo Registrar al Usuario" + error)
                //     this.controlProcesos = false;
                // });
        }) // email post
        .catch(error => {
          console.log("NO SE PUDO GRABAR EL MAIL: " + error)
          this.controlProcesos = false;
        });

      }else{
        console.log("NO HAY CONEXION CON EL SERVIDOR")
      }
  };// FIN SUBMIT
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
