export class TipoTransaccion {
    public Id_tipo_transaccion : number
    public Descripcion : string
    public Valor_comision : number
  constructor(
    // _Id_tipo_transaccion : number,
    // _Descripcion : string,
    // _Valor_comision : number
  )
  {
    this.Id_tipo_transaccion = 0;
    this.Descripcion = "";
    this.Valor_comision = 0;
    // this.Id_tipo_transaccion = _Id_tipo_transaccion;
    // this.Descripcion = _Descripcion;
    // this.Valor_comision = _Valor_comision;
  }
}