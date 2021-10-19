import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BodyComponent } from './main/body/body.component';
import { LoginComponent } from './login/login.component';
import { ErrorComponent} from './error/error.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component';
import { NosotrosComponent } from './nosotros/nosotros.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ConfiguracionComponent } from './configuracion/configuracion.component';
import { FaqComponent } from './faq/faq.component';
import { IngresarDineroComponent } from './ingresar-dinero/ingresar-dinero.component';

import { EfectivoComponent } from './ingresar-dinero/efectivo/efectivo.component';
import { TarjetaDebitoComponent } from './ingresar-dinero/tarjeta-debito/tarjeta-debito.component';

const routes: Routes = [
  { path: '', component: BodyComponent, pathMatch:'full' },
  { path: "login", component: LoginComponent, pathMatch: "full" },
  { path: "registro", component: RegistroUsuarioComponent, pathMatch: "full" },
  { path: "nosotros", component: NosotrosComponent, pathMatch: 'full' },
  { path: "dashboard", component: DashboardComponent, pathMatch: 'full' },
  { path: 'ingresar-dinero', component: IngresarDineroComponent, pathMatch: 'full'},
  { path: "efectivo", component: EfectivoComponent, pathMatch: 'full' },
  { path: "tarjeta-debito", component: TarjetaDebitoComponent, pathMatch: 'full' },
  { path: "configuracion", component: ConfiguracionComponent, pathMatch: 'full' },
  { path: "faq", component: FaqComponent, pathMatch: 'full' },
  { path: '**', component:ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
