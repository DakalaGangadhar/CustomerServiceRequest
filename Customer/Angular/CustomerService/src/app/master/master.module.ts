import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MasterComponent } from './master/master.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { Mainroutes } from '../routing/mainroute';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { NgCircleProgressModule } from 'ng-circle-progress';



@NgModule({
  declarations: [
    MasterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule.forRoot(Mainroutes),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  bootstrap: [MasterComponent]
})
export class MasterModule { }
