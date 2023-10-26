import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './common/dash-board.component';
import { LoginComponent } from './common/login.component';

const routes: Routes = [
  { path: '', redirectTo:'login' ,pathMatch:'full'},
  { path: 'dashboard', component: DashBoardComponent ,data: { title: 'Dashboard' }},
  { path: 'login', component: LoginComponent ,data: { title: 'LogIn' }},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
