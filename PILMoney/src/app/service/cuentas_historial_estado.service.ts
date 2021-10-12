import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CuentasHistorialEstado } from '../Modelos/cuentas_historial_estado.model';

@Injectable({
  providedIn: 'root'
})
export class CuentasHistorialEstadoService {

  private rootURL = "https://localhost:44344/api/CuentaHistorialEstados";
    
  constructor(private httprequest : HttpClient) { }

  // ***** GET GENERAL
  getTodos():Promise<CuentasHistorialEstado[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<CuentasHistorialEstado[]>(this.rootURL).toPromise();
  }
  //  ***** GET POR ID
  getxId(id:number):Promise<CuentasHistorialEstado[]>{
    // hago el get indico que recibo un array de objetos tipo Rol
    return this.httprequest.get<CuentasHistorialEstado[]>(`${this.rootURL}/${id}`).toPromise();
  }
  //  ***** POST
  postRol(datos : CuentasHistorialEstado):Promise<any>{
    return this.httprequest.post<CuentasHistorialEstado>(this.rootURL, datos).toPromise();
  }
  // ***** PUT POR ID
  putRol(id:number, datos : CuentasHistorialEstado):Promise<any>{
    return this.httprequest.put<CuentasHistorialEstado>(`${this.rootURL}/${id}`, datos).toPromise();
  }
  //  ***** DELETE POR ID
  deleteRol(id:number):Promise<any>{
    return this.httprequest.delete<CuentasHistorialEstado>(`${this.rootURL}/${id}`).toPromise();
  }

}
