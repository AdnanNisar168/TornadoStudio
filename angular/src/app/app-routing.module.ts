import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './common/dash-board.component';
import { LoginComponent } from './common/login.component';
import { UserListComponent } from './hr/user-list.component';
import { UserComponent } from './hr/user.component';
import { TestListComponent } from './hr/test-list.component';
import { TestComponent } from './hr/test.component';

const routes: Routes = [
  { path: '', redirectTo:'login' ,pathMatch:'full'},
  { path: 'dashboard', component: DashBoardComponent ,data: { title: 'Dashboard' }},
  { path: 'login', component: LoginComponent ,data: { title: 'LogIn' }},
  { path: 'user/list', component: UserListComponent ,data: { title: 'User List' }},
  { path: 'user/:id', component: UserListComponent ,data: { title: 'User ' }},
  { path: 'user', component: UserComponent ,data: { title: 'User ' }},
  { path: 'test/list', component: TestListComponent ,data: { title: 'Test List ' }},
  { path: 'test/:id', component: TestComponent ,data: { title: 'Test  ' }},
  { path: 'test', component: TestComponent ,data: { title: 'Test  ' }},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
