import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SaldoCuenta } from '../Modelos/saldoCuenta.model';

@Injectable({
  providedIn: 'root'
})
export class SaldoCuentaService {

  private rootURL = "https://localhost:44344/api/SaldoCuenta";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<SaldoCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<SaldoCuenta[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<SaldoCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<SaldoCuenta[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : SaldoCuenta):Promise<any>{
    return this.httprequest.post<SaldoCuenta>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : SaldoCuenta):Promise<any>{
    return this.httprequest.put<SaldoCuenta>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<SaldoCuenta>(`${this.rootURL}/${id}`).toPromise();
  }

}
