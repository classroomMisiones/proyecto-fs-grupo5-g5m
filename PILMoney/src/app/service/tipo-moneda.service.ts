import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TipoMoneda } from '../Modelos/tipoMoneda.model';

@Injectable({
  providedIn: 'root'
})
export class TipoMonedaervice {

  private rootURL = "https://localhost:44344/api/TipoMoneda";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<TipoMoneda[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoMoneda[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<TipoMoneda[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoMoneda[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : TipoMoneda):Promise<any>{
    return this.httprequest.post<TipoMoneda>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : TipoMoneda):Promise<any>{
    return this.httprequest.put<TipoMoneda>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<TipoMoneda>(`${this.rootURL}/${id}`).toPromise();
  }

}
