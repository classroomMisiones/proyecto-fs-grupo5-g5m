import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Telefono } from '../Modelos/telefono.model';

@Injectable({
  providedIn: 'root'
})
export class TelefonoService {
  private rootURL = "https://localhost:44344/api/Telefono";
    
  constructor(private httprequest : HttpClient) { }
  
  // ***** GET GENERAL
  getTodos():Promise<Telefono[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Telefono[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Telefono[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Telefono[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Telefono):Promise<any>{
    return this.httprequest.post<Telefono>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Telefono):Promise<any>{
    return this.httprequest.put<Telefono>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Telefono>(`${this.rootURL}/${id}`).toPromise();
  }
  
}
