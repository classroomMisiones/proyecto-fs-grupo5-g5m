import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginUsuarios } from '../Modelos/loginUsuarios.model';

@Injectable({
  providedIn: 'root'
})
export class LoginLoginRequestService {

  private rootURL = "https://localhost:44344/api/LoginUsuarios";

  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<LoginUsuarios[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<LoginUsuarios[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<LoginUsuarios[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<LoginUsuarios[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : LoginUsuarios):Promise<any>{
    return this.httprequest.post<LoginUsuarios>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : LoginUsuarios):Promise<any>{
    return this.httprequest.put<LoginUsuarios>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<LoginUsuarios>(`${this.rootURL}/${id}`).toPromise();
  }

}
