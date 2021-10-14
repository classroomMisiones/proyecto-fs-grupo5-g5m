import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Pais } from '../Modelos/pais.model';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

  private rootURL = "https://localhost:44344/api/Pais";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Pais[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Pais[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Pais[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Pais[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Pais):Promise<any>{
    return this.httprequest.post<Pais>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Pais):Promise<any>{
    return this.httprequest.put<Pais>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Pais>(`${this.rootURL}/${id}`).toPromise();
  }
  

}
