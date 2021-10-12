import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EstadoCuenta } from '../Modelos/estado_cuenta.model';

@Injectable({
  providedIn: 'root'
})
export class EstadoCuentaService {

  private rootURL = "https://localhost:44344/api/EstadoCuenta";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<EstadoCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<EstadoCuenta[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<EstadoCuenta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<EstadoCuenta[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : EstadoCuenta):Promise<any>{
    return this.httprequest.post<EstadoCuenta>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : EstadoCuenta):Promise<any>{
    return this.httprequest.put<EstadoCuenta>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<EstadoCuenta>(`${this.rootURL}/${id}`).toPromise();
  }

}
