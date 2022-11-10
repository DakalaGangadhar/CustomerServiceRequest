import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridComponent } from './grid/grid.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { adminroute } from '../routing/admin';



@NgModule({
  declarations: [
    GridComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(adminroute),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ]
})
export class AdminModule { }
