import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginRequest } from '../Modelos/LoginRequest.model';

@Injectable({
  providedIn: 'root'
})
export class LoginRequestService {

  
  private rootURL_get_echoping = "https://localhost:44344/api/login/echoping";
  private rootURL_get_echouser = "https://localhost:44344/api/login/echouser";
  private rootURL_post_authenticate = "https://localhost:44344/api/login/authenticate";
    
  constructor(private httprequest : HttpClient) { }

  // **********************
  // **** A VER ESTO ****
  // **********************

  // ***** GET GENERAL
  getTodos(id:number):Promise<LoginRequest[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<LoginRequest[]>(`${this.rootURL_get_echoping}/${id}`).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<LoginRequest[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<LoginRequest[]>(`${this.rootURL_get_echouser}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : LoginRequest):Promise<any>{
    return this.httprequest.post<LoginRequest>(this.rootURL_post_authenticate, datos).toPromise();
  }
  // // ***** PUT POR ID
  // putRol(id:number, datos : LoginRequest):Promise<any>{
  //   return this.httprequest.put<LoginRequest>(`${this.rootURL}/${id}`, datos).toPromise();
  // }
  // //  ***** DELETE POR ID
  // deleteRol(id:number):Promise<any>{
  //   return this.httprequest.delete<LoginRequest>(`${this.rootURL}/${id}`).toPromise();
  // }

}

