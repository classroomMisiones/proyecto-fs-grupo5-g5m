import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TransaccionesCuenta } from '../Modelos/transaccionesCuenta.model';

@Injectable({
  providedIn: 'root'
})
export class TransaccionesCuentaService {

  private rootURL = "https://localhost:44344/api/TransaccionesCuenta";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<TransaccionesCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TransaccionesCuenta[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<TransaccionesCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TransaccionesCuenta[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : TransaccionesCuenta):Promise<any>{
    return this.httprequest.post<TransaccionesCuenta>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : TransaccionesCuenta):Promise<any>{
    return this.httprequest.put<TransaccionesCuenta>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<TransaccionesCuenta>(`${this.rootURL}/${id}`).toPromise();
  }

}
