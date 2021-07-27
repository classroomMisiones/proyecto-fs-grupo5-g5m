import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BodyComponent } from './main/body/body.component';
import { LoginComponent } from './login/login.component';
import { ErrorComponent} from './error/error.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component'

const routes: Routes = [

  { path: 'main', component: BodyComponent, pathMatch:'full' },
  { path: "login", component: LoginComponent, pathMatch: "full" },
  { path: "registro", component: RegistroUsuarioComponent, pathMatch: "full" },
  { path:'**', component:ErrorComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
