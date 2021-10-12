import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TipoTransaccion } from '../Modelos/tipoTransaccion.model';

@Injectable({
  providedIn: 'root'
})
export class TipoTransaccionService {

  private rootURL = "https://localhost:44344/api/TipoTransaccion";

  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<TipoTransaccion[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoTransaccion[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<TipoTransaccion[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoTransaccion[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : TipoTransaccion):Promise<any>{
    return this.httprequest.post<TipoTransaccion>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : TipoTransaccion):Promise<any>{
    return this.httprequest.put<TipoTransaccion>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<TipoTransaccion>(`${this.rootURL}/${id}`).toPromise();
  }
}
