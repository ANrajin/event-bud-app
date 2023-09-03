import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicComponent } from './public.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';



@NgModule({
  declarations: [
    PublicComponent,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PublicModule { }
