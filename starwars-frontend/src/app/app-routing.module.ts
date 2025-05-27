import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'; 
import { SecondComponentComponent } from './second-component/second-component.component';
import { BasicComponentComponent } from './basic-component/basic-component.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
    { path: 'basic', component: BasicComponentComponent },
    { path: 'second', component: SecondComponentComponent, canActivate: [AuthGuard],},
    { path: 'login', component: LoginComponent },
]; 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }