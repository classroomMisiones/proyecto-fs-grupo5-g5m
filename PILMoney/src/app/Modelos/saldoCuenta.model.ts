export class SaldoCuenta {
  constructor(
    public Id_saldo : number,
    public Id_usuario : number,
    public Id_moneda : number,
    public Saldo : number,
    public Fecha : string,
    public Hora : string
  )
  {

  }
}