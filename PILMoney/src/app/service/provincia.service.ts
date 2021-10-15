import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Provincia } from '../Modelos/provincia.model';

@Injectable({
  providedIn: 'root'
})
export class ProvinciaService {

  private rootURL = "https://localhost:44344/api/Provincia";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Provincia[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Provincia[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Provincia[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Provincia[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Provincia):Promise<any>{
    return this.httprequest.post<Provincia>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Provincia):Promise<any>{
    return this.httprequest.put<Provincia>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Provincia>(`${this.rootURL}/${id}`).toPromise();
  }

}
