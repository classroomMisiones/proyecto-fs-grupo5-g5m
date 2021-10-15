import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Rol } from '../Modelos/rol.model';


@Injectable({
  providedIn: 'root'
})

export class RolService {
  
  private rootURL = "https://localhost:44344/api/Rol";
  
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Rol[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Rol[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Rol[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Rol[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : Rol):Promise<any>{
    console.log(`datos recibidos en el Post: ${datos},${datos.Id_rol},${datos.Descripcion} `)
    return this.httprequest.post<Rol>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : Rol):Promise<any>{
    return this.httprequest.put<Rol>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<Rol>(`${this.rootURL}/${id}`).toPromise();
  }

}
