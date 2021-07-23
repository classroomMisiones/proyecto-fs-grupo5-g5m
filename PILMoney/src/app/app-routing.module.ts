import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
import { ErrorComponent} from'./error/error.component';
=======
import { ErrorComponent} from './error/error.component';
>>>>>>> e6fb47fd5423ee883939181b025562abc98538ca

const routes: Routes = [
  {
    path: '**',
    component:ErrorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }