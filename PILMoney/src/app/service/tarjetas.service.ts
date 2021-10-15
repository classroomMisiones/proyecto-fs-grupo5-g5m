import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Tarjeta } from '../Modelos/tarjetas.model';

@Injectable({
  providedIn: 'root'
})
export class TarjetasService {

  private rootURL = "https://localhost:44344/api/Tarjetas";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Tarjeta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Tarjeta[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Tarjeta[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Tarjeta[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Tarjeta):Promise<any>{
    return this.httprequest.post<Tarjeta>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Tarjeta):Promise<any>{
    return this.httprequest.put<Tarjeta>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Tarjeta>(`${this.rootURL}/${id}`).toPromise();
  }

}
