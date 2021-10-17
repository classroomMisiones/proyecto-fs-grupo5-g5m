import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginUsuarios } from '../Modelos/loginUsuarios.model';

import { N_token } from '../Interfaces/N_token.interface';

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
  //  ***** POST LogIn
  postLoginUsuario(datos : N_token):Promise<any>{
    return this.httprequest.post<N_token>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putLoginUsuario(id:number):Promise<any>{
    return this.httprequest.put(`${this.rootURL}/${id}`, 0).toPromise();
  }
  //  ***** DELETE POR ID
  deletepostLoginUsuario(id:number):Promise<any>{
    return this.httprequest.delete<LoginUsuarios>(`${this.rootURL}/${id}`).toPromise();
  }

}
