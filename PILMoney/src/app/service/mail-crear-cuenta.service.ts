import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root'
})
export class MailCrearCuentaService {

  private rootURL = environment.UrlBaseApi;
  //"https://localhost:44344/api/Rol";
  
  constructor(private httprequest : HttpClient)
  { }

  // ***** GET GENERAL
  getId():Promise<number>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<number>(`${this.rootURL}/MailCrearCuenta`).toPromise();
  }
}
