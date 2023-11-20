import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashBoardComponent } from './common/dash-board.component';
import { LoginComponent } from './common/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { UserListComponent } from './hr/user-list.component';
import { UserComponent } from './hr/user.component';

@NgModule({
  declarations: [
    AppComponent,
    DashBoardComponent,
    LoginComponent,
    UserListComponent,
    UserComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, // Add HttpClientModule
    ReactiveFormsModule, // Add ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
