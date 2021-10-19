import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ErrorComponent } from './error/error.component';
import { NavbarComponent } from './main/navbar/navbar.component';
import { FooterComponent } from './main/footer/footer.component';
import { BodyComponent } from './main/body/body.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component';
import { FormularioComponent } from './registro-usuario/formulario/formulario.component';
import { LoginComponent } from './login/login.component';
import { NosotrosComponent } from './nosotros/nosotros.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ConfiguracionComponent } from './configuracion/configuracion.component';
import { IngresarDineroComponent } from './ingresar-dinero/ingresar-dinero.component';
import { EfectivoComponent } from './ingresar-dinero/efectivo/efectivo.component';
import { TarjetaDebitoComponent } from './ingresar-dinero/tarjeta-debito/tarjeta-debito.component';


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
    NosotrosComponent,
    DashboardComponent,
    ConfiguracionComponent,
    IngresarDineroComponent,
    EfectivoComponent,
    TarjetaDebitoComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
