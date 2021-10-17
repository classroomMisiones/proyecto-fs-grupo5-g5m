import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { CriptoaApiService } from '../service/moneda-api.service';
import { LoginLoginRequestService } from '../service/login-usuarios.service'; 
import { NTokenService } from '../service/n-token.service'; 
import { TransaccionesCuentaService } from '../service/transacciones-cuenta.service';
import { TipoTransaccionService } from '../service/tipo-transaccion.service'; 

import { TransaccionesCuenta } from '../Modelos/transaccionesCuenta.model';
import { TipoTransaccion } from '../Modelos/tipoTransaccion.model';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    
    valoresCripto : Array<string>;
    ColorActualizoCripto : any;
    ColorActualizoCriptos  : any;
    arrTransacciones : TransaccionesCuenta[];
    arrComionesVigentes : TipoTransaccion[];
        
    constructor(private criptoaApiService : CriptoaApiService, 
                private transaccionesCuentaService : TransaccionesCuentaService,
                private loginLoginRequestService : LoginLoginRequestService,
                private nTokenService : NTokenService,
                private tipoTransaccionService : TipoTransaccionService, 
                private route : Router
    ) 
    { 
      this.ColorActualizoCripto = {color: '#fff'};
      this.ColorActualizoCriptos =  {color: '#0907B8'};
      this.valoresCripto = ["","","","",""]      
      this.arrTransacciones = [];
      this.arrComionesVigentes = [];
    }

  // ****** VER MOVIMIENTOS EN PESOS
  movimientosPesos(){
    console.log("******************** BUSCO MOVIMIENTOS")
    this.transaccionesCuentaService.getxId(6) // RECIBO LAS RESPUESTA DEL POST
    .then(respuesta => {
      this.arrTransacciones = respuesta;
      console.log(this.arrTransacciones[0].Fecha);
      console.log(respuesta);
    })
    .catch(error => console.log(`Error desde el POST ${error}`) );
  };

// ****** VER MOVIMIENTOS EN CRIPTO
  movimientosCriptos(){

  };
// ***************************************************************
// ************ COMISIONES VIGENTES ***********************
// ***************************************************************
  onClikComisiones(){
    console.log("******************** BUSCO LAS COMISIONES")
    this.tipoTransaccionService.getTodos() // RECIBO LAS RESPUESTA DEL POST
    .then(respuesta => {
      this.arrComionesVigentes = respuesta;
      console.log(respuesta);
      console.log(this.arrComionesVigentes);
    })
    .catch(error => console.log(`Error desde el POST ${error}`) );
  };
  

// ***************************************************************
// ************** Acciones al salir del dashboard ****************
// ***************************************************************
  onClickLogOut(){
    // ***** OBtengo el token desde local storage
    const token = localStorage.getItem('miToken');
    console.log("EL TOKEN: " + token)
    // // ***** OBtengo el Id usuario
    // if (token){
    //   this.nTokenService.getId(token)
    //   .then( IdUsuario =>{
    //       // **** Grabo el login out en la BBDD
    //       this.loginLoginRequestService.putLoginUsuario(IdUsuario)
    //       .then(() =>{
    //           console.log('OK; SE GRABO EL LogOut EN BBDD')
    //       })
    //       .catch(error => console.log("NO SE PUDO GRABAR EL LOGOUT ERROR: " + error)
    //       );
    //   })
    //   .catch(error => {
    //       console.log("NO SE PUDO OBTENER EL ID: " + error)
    //   });      
    // }
  }

  // ***************************************************************
  // ***************** CONSULTA API CRIPTO *************************
  // ***************************************************************

  consultarAPI(){
    this.ColorActualizoCripto.color =  this.ColorActualizoCriptos.color = '#0907B8';
    this.criptoaApiService.getCotizacion() // RECIBO LAS RESPUESTA DEL POST
        .then(respuesta => {
          this.valoresCripto[0]=respuesta.DISPLAY.BTC.ARS.PRICE;
          this.valoresCripto[1]=respuesta.DISPLAY.BTC.ARS.HIGHDAY;
          this.valoresCripto[2]=respuesta.DISPLAY.BTC.ARS.LOWDAY;
          this.valoresCripto[3]=respuesta.DISPLAY.BTC.ARS.CHANGEPCT24HOUR;
          this.valoresCripto[4]=respuesta.DISPLAY.BTC.ARS.LASTUPDATE;
        })
        .catch(error => console.log(`Error desde el POST ${error}`) 
        );
            
        setTimeout(() => {
          this.ColorActualizoCripto.color = '#fff'
          this.ColorActualizoCriptos.color = '#E10101'
        }, 1000); 
  }

  ngOnInit(): void {
    this.consultarAPI()

    setInterval(()=>{
      this.consultarAPI()
    },8000);
  }


  ngOnDestroy(){
    clearInterval();
    localStorage.removeItem('miToken');
  }

}

// "DISPLAY":{"BTC":

// {"ARS":
// {"PRICE":"ARS 10,522,041.9",

// 	"LASTUPDATE":"Just now",
// 	"HIGHDAY":"ARS 10,689,524.6",
// 	"LOWDAY":"ARS 10,401,560.0",
// 	"CHANGE24HOUR":"ARS 535,532"
// }
// }
// }