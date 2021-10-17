import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { N_token } from '../Interfaces/N_token.interface';
import { loginInterface } from '../Interfaces/login.interface';


import { Usuarios } from '../Modelos/usuarios.model';

@Injectable({
  providedIn: 'root'
})

export class UsuariosService {
  
  private rootURL = environment.UrlBaseApi + "/Usuario";
  //private rootURL = "https://localhost:44344/api/Usuario";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Usuarios[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Usuarios[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Usuarios[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Usuarios[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postUsuario(datos : Usuarios):Promise<any>{
    return this.httprequest.post<Usuarios>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putUsuario(id:number, datos : Usuarios):Promise<any>{
    return this.httprequest.put<Usuarios>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteUsuario(id:number):Promise<any>{
    return this.httprequest.delete<Usuarios>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** PUT TOKEN ******************* ????????????????????????????????????????
  PutToken(datostoken:N_token):Promise<N_token>{
    return this.httprequest.post<N_token>(`${this.rootURL}`, datostoken).toPromise();
  }

}