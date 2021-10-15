export class Comisiones {
    public Id_comision : number
    public Id_transaccion : number
    public Id_moneda : number
    public Porcentaje_comision : number
    public Monto_comision : number
    public Fecha : string
  constructor(
    // _Id_comision : number,
    // _Id_transaccion : number,
    // _Id_moneda : number,
    // _Porcentaje_comision : number,
    // _Monto_comision : number,
    // _Fecha : string
  )
  {
    this.Id_comision = 0;
    this.Id_transaccion = 0;
    this.Id_moneda = 0;
    this.Porcentaje_comision = 0;
    this.Monto_comision = 0;
    this.Fecha = "";
    // this.Id_comision = _Id_comision;
    // this.Id_transaccion = _Id_transaccion;
    // this.Id_moneda = _Id_moneda;
    // this.Porcentaje_comision = _Porcentaje_comision;
    // this.Monto_comision = _Monto_comision;
    // this.Fecha = _Fecha;
  }
}