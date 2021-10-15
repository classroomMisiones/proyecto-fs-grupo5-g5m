import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Usuarios } from '../Modelos/usuarios.model';

@Injectable({
  providedIn: 'root'
})

export class UsuariosService {

  private rootURL = "https://localhost:44344/api/Usuario";
    
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
  postRol(datos : Usuarios):Promise<any>{
    return this.httprequest.post<Usuarios>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Usuarios):Promise<any>{
    return this.httprequest.put<Usuarios>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Usuarios>(`${this.rootURL}/${id}`).toPromise();
  }
  

}