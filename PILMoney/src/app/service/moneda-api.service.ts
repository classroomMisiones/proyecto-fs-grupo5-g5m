import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class CriptoaApiService {

  private rootURL = "https://min-api.cryptocompare.com/data/pricemultifull?fsyms=BTC&tsyms=ARS";

  constructor(private httprequest : HttpClient) { }

  getCotizacion():Promise<any>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<any>(this.rootURL).toPromise();
  }

}
