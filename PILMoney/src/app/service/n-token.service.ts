import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { N_token } from '../Interfaces/N_token.interface';

@Injectable({
  providedIn: 'root'
})
export class NTokenService {
  private rootURL = environment.UrlBaseApi;
  // "https://localhost:44344/api/N_token";

  constructor(private httprequest : HttpClient) { }

  //  ***** PUT TOKEN ******************* ????????????????????????????????????????
  PutToken(datostoken:N_token):Promise<N_token>{
    return this.httprequest.put<N_token>(`${this.rootURL}/N_token`, datostoken).toPromise();
  }
  
  // ***** GET ID POR token
  getId(token:string):Promise<number>{
    //return this.httprequest.get<number>(`${this.rootURL}/N_token/${token}`).toPromise();
    return this.httprequest.get<number>(`${this.rootURL}/N_token?cadena=${token}`).toPromise();
  }

  // ***** GET GENERAL
  // getTodos():Promise<Usuarios[]>{
  // hago el get indico que recibo un array de objetos tipo Rol
  //   return this.httprequest.get<Usuarios[]>(this.rootURL).toPromise();
  // }
  //  ***** POST
  // postUsuario(datos : N_token):Promise<any>{
  //   return this.httprequest.post<N_token>(this.rootURL, datos).toPromise();
  // }
  // ***** PUT POR ID
  // putUsuario(id:number, datos : Usuarios):Promise<any>{
  //   return this.httprequest.put<Usuarios>(`${this.rootURL}/${id}`, datos).toPromise();
  // }
  //  ***** DELETE POR ID
  // deleteUsuario(id:number):Promise<any>{
  //   return this.httprequest.delete<Usuarios>(`${this.rootURL}/${id}`).toPromise();
  // }
  

}
