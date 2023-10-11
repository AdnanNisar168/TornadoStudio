import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './common/dash-board.component';

const routes: Routes = [
  { path: 'dashboard', component: DashBoardComponent ,data: { title: 'Dashboard' }},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
