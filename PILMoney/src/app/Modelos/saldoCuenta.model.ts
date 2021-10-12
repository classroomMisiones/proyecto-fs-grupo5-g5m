export class SaldoCuenta {
    public Id_saldo : number
    public Id_usuario : number
    public Id_moneda : number
    public Saldo : number
    public Fecha : string
    public Hora : string
  constructor(
    // _Id_saldo : number,
    // _Id_usuario : number,
    // _Id_moneda : number,
    // _Saldo : number,
    // _Fecha : string,
    // _Hora : string
  )
  {
    this.Id_saldo = 0;
    this.Id_usuario = 0;
    this.Id_moneda  = 0;
    this.Saldo = 0;
    this.Fecha = "";
    this.Hora = "";
    // this.Id_saldo = _Id_saldo;
    // this.Id_usuario = _Id_usuario;
    // this.Id_moneda  = _Id_moneda ;
    // this.Saldo = _Saldo;
    // this.Fecha = _Fecha;
    // this.Hora = _Hora;
  }
}