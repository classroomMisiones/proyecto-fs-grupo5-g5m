export class Tarjeta{
    public Id_tarjeta : number
    public Numero_tarjeta : string
    public Fecha_vencimiento : string
    public Id_usuario : number
  constructor(
    // _Id_tarjeta : number,
    // _Numero_tarjeta : string,
    // _Fecha_vencimiento : string,
    // _Id_usuario : number
  )
  {
    this.Id_tarjeta  = 0;
    this.Numero_tarjeta = "";
    this.Fecha_vencimiento = "";
    this.Id_usuario = 0;
    // this.Id_tarjeta  = _Id_tarjeta;
    // this.Numero_tarjeta = _Numero_tarjeta;
    // this.Fecha_vencimiento = _Fecha_vencimiento;
    // this.Id_usuario = _Id_usuario;
  }
}