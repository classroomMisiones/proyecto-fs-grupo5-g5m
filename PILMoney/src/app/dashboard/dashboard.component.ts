import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { CriptoaApiService } from '../service/moneda-api.service';
import { LoginLoginRequestService } from '../service/login-usuarios.service'; 
import { NTokenService } from '../service/n-token.service'; 
import { TransaccionesCuentaService } from '../service/transacciones-cuenta.service';
import { TipoTransaccionService } from '../service/tipo-transaccion.service'; 
import { SaldoCuentaService } from '../service/saldo-cuenta.service'



import { TransaccionesCuenta } from '../Modelos/transaccionesCuenta.model';
import { TipoTransaccion } from '../Modelos/tipoTransaccion.model';
import { SaldoCuenta } from '../Modelos/saldoCuenta.model';

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
    private token : any;
    private ID : number;
    arrSaldoCuenta : SaldoCuenta[];
        
    constructor(private criptoaApiService : CriptoaApiService, 
                private transaccionesCuentaService : TransaccionesCuentaService,
                private loginLoginRequestService : LoginLoginRequestService,
                private nTokenService : NTokenService,
                private tipoTransaccionService : TipoTransaccionService,
                private saldoCuentaService : SaldoCuentaService,
                private route : Router
    ) 
    { 
      this.ColorActualizoCripto = {color: '#fff'};
      this.ColorActualizoCriptos =  {color: '#0907B8'};
      this.valoresCripto = ["","","","",""]      
      this.arrTransacciones = [];
      this.arrComionesVigentes = [];
      this.ID = 0;
      this.arrSaldoCuenta = [];
      
    }

// ***************************************************************
// ******************** SALDO EN CUENTA *************************
// ***************************************************************

    

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
  // ***************** CONSULTA API CRIPTO *************************
  // ***************************************************************

  consultarAPI(){
    // ***** cambio el color del texto
    this.ColorActualizoCripto.color =  this.ColorActualizoCriptos.color = '#0907B8';
    // ***** Hago la consulta a la API por los valores de la cripto
    this.criptoaApiService.getCotizacion() // RECIBO LAS RESPUESTA DEL POST
        .then(respuesta => {
          // ***** Guardo los datos en un array
          this.valoresCripto[0]=respuesta.DISPLAY.BTC.ARS.PRICE;
          this.valoresCripto[1]=respuesta.DISPLAY.BTC.ARS.HIGHDAY;
          this.valoresCripto[2]=respuesta.DISPLAY.BTC.ARS.LOWDAY;
          this.valoresCripto[3]=respuesta.DISPLAY.BTC.ARS.CHANGEPCT24HOUR;
          this.valoresCripto[4]=respuesta.DISPLAY.BTC.ARS.LASTUPDATE;
        })
        .catch(error => console.log(`Error desde el POST ${error}`) 
        );
            
        setTimeout(() => {
          // ***** ciclo de espera para cambiar el color del texto
          this.ColorActualizoCripto.color = '#fff'
          this.ColorActualizoCriptos.color = '#E10101'
        }, 1000); 
  }

  ngOnInit() {
    // ***** Hago la consulta a la API por los valores de la cripto
    this.consultarAPI();

    setInterval(()=>{
      // ***** Inicio un interval que cada 10 segundos actualiza los valores de la cripto
      this.consultarAPI()
    },10000);

    
    this.onClikComisiones();
          // ***** tomo el token desde local storage
          // ***** Guardo el token en un atributo privado  
          this.token = localStorage.getItem('miToken');
          //console.log(this.token);
    
          // ***** tomo el ID del usuario desde la BBDD
          this.nTokenService.getId(this.token)
          .then( IdUsuario =>{
            // ***** Guardo el ID en un atributo privado  
            this.ID = IdUsuario;
             //console.log(`ID RECUPERADO: ${this.ID}`);
              // ***** Busco los registros de saldos
              this.saldoCuentaService.getxId(this.ID) // RECIBO LAS RESPUESTA DEL POST
              .then(respuesta => {
                  // ***** Guardo los registroe en un array
                  this.arrSaldoCuenta = respuesta;
                  console.log(this.arrSaldoCuenta);
              })
              .catch(error => console.log(`Error desde el POST ${error}`)
              );
          })
          .catch(error => {
              console.log( `NO SE PUDO OBTENER EL ID:  ${error}`)
          });        

  }

  // ***************************************************************
  // ************** Acciones al salir del dashboard ****************
  // ***************************************************************
  onClickLogOut(){
    // ***** Realizo el put de la fecha y hora del LogOut
    // **** Grabo el login out en la BBDD
    this.loginLoginRequestService.putLoginUsuario(this.ID)
    .then(() =>{
    console.log('OK; SE GRABO EL LogOut EN BBDD')
    })
    .catch(error => console.log("NO SE PUDO GRABAR EL LOGOUT ERROR: " + error)
    );
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