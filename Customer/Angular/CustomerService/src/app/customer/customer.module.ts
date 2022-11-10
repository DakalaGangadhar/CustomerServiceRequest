import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { RouterModule } from '@angular/router';
import { customerroute } from '../routing/customerroute';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegistrationService } from '../services/registration.service';
import { TokenInterceptorService } from '../services/TokenInterceptorService';



@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(customerroute),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [RegistrationService,{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true},DatePipe],
 
})
export class CustomerModule { }
