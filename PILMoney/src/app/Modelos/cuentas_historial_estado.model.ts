export class CuentasHistorialEstado {
  constructor(
    public Id_historia_cuenta : number,
    public Fecha_hora : string,
    public Id_estado_cuenta : number,
    public Id_cuenta : number,
    public Id_usuario : number
  )
  {
    
  }
}