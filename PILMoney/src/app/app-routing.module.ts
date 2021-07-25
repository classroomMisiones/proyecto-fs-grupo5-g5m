import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent} from './error/error.component';

import { BodyComponent } from './main/body/body.component';

const routes: Routes = [
  {
    path:'iniciobody',
    component:BodyComponent,
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }