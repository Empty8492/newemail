import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { AppRoutingModule } from './app-routing.module';
import { TableComponent } from './component/table/table.component';
import { HomeComponent } from './component/home/home.component';

import { EmailComponent } from './component/email/email.component';
import { UpdateComponent } from './component/update/update.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TableComponent,
    HomeComponent,

    EmailComponent,

    UpdateComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
