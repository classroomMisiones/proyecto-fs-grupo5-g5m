import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorComponent } from './error/error.component';
import { NavbarComponent } from './main/navbar/navbar.component';
import { FooterComponent } from './main/footer/footer.component';
import { BodyComponent } from './main/body/body.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component';
import { FormularioComponent } from './registro-usuario/formulario/formulario.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent,
    NavbarComponent,
    FooterComponent,
    BodyComponent,
    RegistroUsuarioComponent,
    FormularioComponent,
    LoginComponent,
    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
