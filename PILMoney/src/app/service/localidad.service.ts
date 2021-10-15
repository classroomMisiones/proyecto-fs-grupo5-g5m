import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Localidad } from '../Modelos/localidad.model';

@Injectable({
  providedIn: 'root'
})
export class LocalidadService {

  private rootURL = "https://localhost:44344/api/Localidad";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Localidad[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Localidad[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Localidad[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Localidad[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Localidad):Promise<any>{
    return this.httprequest.post<Localidad>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Localidad):Promise<any>{
    return this.httprequest.put<Localidad>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Localidad>(`${this.rootURL}/${id}`).toPromise();
  }

}