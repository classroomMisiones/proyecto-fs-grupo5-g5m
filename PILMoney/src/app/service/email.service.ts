import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Email } from '../Modelos/email.model';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  private rootURL = "https://localhost:44344/api/Email";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<Email[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Email[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<Email[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<Email[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** GET BUSCA EL ID MAIL POR EL MAIL
  getId(email:string):Promise<number>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<number>(`${this.rootURL}/Email?cadena=${email}`).toPromise();
  }
  //  ***** POST
  postMail(datos : Email):Promise<number>{
    return this.httprequest.post<number>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putMail(id:number, datos : Email):Promise<any>{
    return this.httprequest.put<Email>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteMail(id:number):Promise<any>{
    return this.httprequest.delete<Email>(`${this.rootURL}/${id}`).toPromise();
  }
  

}
