export class LoginRequest {
  public Mail : string
  public Password : string
  
  constructor( 
    // _Mail : string = "", 
    // _Password : string = ""
  )
  {
    this.Mail = "";
    this.Password = "";  
    // this.Mail = _Mail;
    // this.Password = _Password;  
  }
}