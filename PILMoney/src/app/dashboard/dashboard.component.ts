import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { CriptoaApiService } from '../service/moneda-api.service';
import { TransaccionesCuentaService } from '../service/transacciones-cuenta.service';

import { TransaccionesCuenta } from '../Modelos/transaccionesCuenta.model';


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
    
    constructor(private criptoaApiService : CriptoaApiService, 
                private transaccionesCuentaService : TransaccionesCuentaService,
                private route : Router) 
    { 
      this.ColorActualizoCripto = {color: '#fff'};
      this.ColorActualizoCriptos =  {color: '#0907B8'};
      this.valoresCripto = ["","","","",""]      
      this.arrTransacciones = [];
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


// **************** CONSULTA API CRIPTO
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
            .catch(error => console.log(`Error desde el POST ${error}`) );
            
            setTimeout(() => {
              this.ColorActualizoCripto.color = '#fff'
              this.ColorActualizoCriptos.color = '#E10101'
            }, 800);
            
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

