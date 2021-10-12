import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Cuentas } from '../Modelos/cuentas.model';

@Injectable({
  providedIn: 'root'
})
export class CuentasService {

  private rootURL = "https://localhost:44344/api/cuentas";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Cuentas[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Cuentas[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Cuentas[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Cuentas[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Cuentas):Promise<any>{
    return this.httprequest.post<Cuentas>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Cuentas):Promise<any>{
    return this.httprequest.put<Cuentas>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Cuentas>(`${this.rootURL}/${id}`).toPromise();
  }

}
