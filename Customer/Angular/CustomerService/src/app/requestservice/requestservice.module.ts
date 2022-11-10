import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreaterequestComponent } from './createrequest/createrequest.component';
import { RouterModule } from '@angular/router';
import { requestroutes } from '../routing/requestroutes';
import { PendingrequestComponent } from './pendingrequest/pendingrequest.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CreaterequestComponent,
    PendingrequestComponent
  ],
  imports: [
    CommonModule,    
    RouterModule.forChild(requestroutes),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RequestserviceModule { }
