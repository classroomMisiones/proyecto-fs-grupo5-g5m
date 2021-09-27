export class TransaccionesCuenta{
  constructor(
    public Id_transaccion : number,
    public Id_usuario : number,
    public Fecha  : string,
    public Hora  : string,
    public Id_tipo_transaccion : number,
    public Id_cuenta_origen : number,
    public Id_moneda_origen : number,
    public Monto_origen : number,
    public Id_cuenta_destino : number,
    public Id_moneda_destino : number,
    public Monto_destino : number,
    
  )
  {

  }
}