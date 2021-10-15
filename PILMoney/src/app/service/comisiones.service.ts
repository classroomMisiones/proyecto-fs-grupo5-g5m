import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Comisiones } from '../Modelos/comisiones.model';

@Injectable({
  providedIn: 'root'
})
export class ComisionesService {

  private rootURL = "https://localhost:44344/api/Comisiones";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Comisiones[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Comisiones[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Comisiones[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Comisiones[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Comisiones):Promise<any>{
    return this.httprequest.post<Comisiones>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Comisiones):Promise<any>{
    return this.httprequest.put<Comisiones>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Comisiones>(`${this.rootURL}/${id}`).toPromise();
  }

}
