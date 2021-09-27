export class Comisiones {
  constructor(
    public Id_comision : number,
    public Id_transaccion : number,
    public Id_moneda : number,
    public Porcentaje_comision : number,
    public Monto_comision : number,
    public Fecha : string
  )
  {
    
  }
}