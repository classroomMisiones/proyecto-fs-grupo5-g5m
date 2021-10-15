export class Cuentas {
    public Id_cuenta : number
    public Cvu : string
    public Id_usuario : number
    public Id_estado_cuenta : number
  constructor(
    // _Id_cuenta : number,
    // _Cvu : string,
    // _Id_usuario : number,
    // _Id_estado_cuenta : number
  )
  {
    this.Id_cuenta = 0;
    this.Cvu = "";
    this.Id_usuario = 0;
    this.Id_estado_cuenta = 0;
    // this.Id_cuenta = _Id_cuenta;
    // this.Cvu = _Cvu;
    // this.Id_usuario = _Id_usuario;
    // this.Id_estado_cuenta = _Id_estado_cuenta;
  }
}
