export class TransaccionesCuenta{
    public Id_transaccion : number
    public Id_usuario : number
    public Fecha  : string
    public Hora  : string
    public Id_tipo_transaccion : number
    public Id_cuenta_origen : number
    public Id_moneda_origen : number
    public Monto_origen : number
    public Id_cuenta_destino : number
    public Id_moneda_destino : number
    public Monto_destino : number
  constructor(
    // _Id_transaccion : number,
    // _Id_usuario : number,
    // _Fecha : string,
    // _Hora : string,
    // _Id_tipo_transaccion : number,
    // _Id_cuenta_origen : number,
    // _Id_moneda_origen : number,
    // _Monto_origen : number,
    // _Id_cuenta_destino : number,
    // _Id_moneda_destino : number,
    // _Monto_destino : number
  )
  {this.Id_transaccion = 0;
    this.Id_usuario = 0;
    this.Fecha = "";
    this.Hora = "";
    this.Id_tipo_transaccion = 0;
    this.Id_cuenta_origen = 0;
    this.Id_moneda_origen = 0;
    this.Monto_origen = 0;
    this.Id_cuenta_destino = 0;
    this.Id_moneda_destino = 0;
    this.Monto_destino = 0;
    // this.Id_transaccion = _Id_transaccion;
    // this.Id_usuario = _Id_usuario;
    // this.Fecha = _Fecha;
    // this.Hora = _Hora;
    // this.Id_tipo_transaccion = _Id_tipo_transaccion;
    // this.Id_cuenta_origen = _Id_cuenta_origen;
    // this.Id_moneda_origen = _Id_moneda_origen;
    // this.Monto_origen = _Monto_origen;
    // this.Id_cuenta_destino = _Id_cuenta_destino;
    // this.Id_moneda_destino = _Id_moneda_destino;
    // this.Monto_destino = _Monto_destino;
  }
}