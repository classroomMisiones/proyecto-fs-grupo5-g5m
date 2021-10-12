import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TipoDocumentoIdentidad } from '../Modelos/tipoDocumentoIdentidad.model';


@Injectable({
  providedIn: 'root'
})
export class TipoDocumentoIdentidadService {

  private rootURL = "https://localhost:44344/api/TipoDocumentoIdentidad";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<TipoDocumentoIdentidad[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoDocumentoIdentidad[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<TipoDocumentoIdentidad[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<TipoDocumentoIdentidad[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : TipoDocumentoIdentidad):Promise<any>{
    return this.httprequest.post<TipoDocumentoIdentidad>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : TipoDocumentoIdentidad):Promise<any>{
    return this.httprequest.put<TipoDocumentoIdentidad>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<TipoDocumentoIdentidad>(`${this.rootURL}/${id}`).toPromise();
  }
  
}
