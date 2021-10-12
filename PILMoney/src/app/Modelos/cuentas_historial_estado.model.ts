export class CuentasHistorialEstado {
    public Id_historia_cuenta : number
    public Fecha_hora : string
    public Id_estado_cuenta : number
    public Id_cuenta : number
    public Id_usuario : number

  constructor(
    // _Id_historia_cuenta : number,
    // _Fecha_hora : string,
    // _Id_estado_cuenta : number,
    // _Id_cuenta : number,
    // _Id_usuario : number
  )
  {
    this.Id_historia_cuenta = 0;
    this.Fecha_hora = "";
    this.Id_estado_cuenta = 0;
    this.Id_cuenta = 0;
    this.Id_usuario = 0;
    // this.Id_historia_cuenta = _Id_historia_cuenta;
    // this.Fecha_hora = _Fecha_hora;
    // this.Id_estado_cuenta = _Id_estado_cuenta;
    // this.Id_cuenta = _Id_cuenta;
    // this.Id_usuario = _Id_usuario;
  }
}