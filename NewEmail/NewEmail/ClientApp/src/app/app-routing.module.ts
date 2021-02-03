import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from './component/table/table.component';
import { HomeComponent } from './component/home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { EmailComponent } from './component/email/email.component';
import { UpdateComponent } from './component/update/update.component';
const routes: Routes = [  
  {
    path: 'email', component: EmailComponent
  }, {
    path: 'emailupdate/:id', component: UpdateComponent
  },
  {
    path: 'home', component: HomeComponent
  },
  {
    path: 'table', component: TableComponent
  },
  { path: '**', redirectTo: 'home' }

];

@NgModule({
  exports: [RouterModule],
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
