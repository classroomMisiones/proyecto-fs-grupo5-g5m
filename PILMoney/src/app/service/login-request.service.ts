import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { loginInterface } from '../Interfaces/login.interface';

@Injectable({
  providedIn: 'root'
})
export class LoginRequestService {

  private rootURL_get_echoping = "https://localhost:44344/api/login/echoping";
  private rootURL_get_echouser = "https://localhost:44344/api/login/echouser";
  private rootURL_post_authenticate = "https://localhost:44344/api/login/authenticate";
    
  constructor(private httprequest : HttpClient) { }

  //  ***** REALIZO EL PING PARA VER SI ESTA ACTIVO EL SERVIDOR
  getPing(){
    return this.httprequest.get<boolean>(`${this.rootURL_get_echoping}`);
  }

  //  ***** SOLICITUD DE TOKEN
  postToken(datos : loginInterface):Promise<any>{
    return this.httprequest.post<loginInterface>(this.rootURL_post_authenticate, datos).toPromise();
  }

  // **********************
  // **** A VER ESTO ****
  // **********************

  // ***** GET GENERAL
  getTodos(id:number):Promise<loginInterface[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<loginInterface[]>(`${this.rootURL_get_echoping}/${id}`).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<loginInterface[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<loginInterface[]>(`${this.rootURL_get_echouser}/${id}`).toPromise();
  }
  
}

