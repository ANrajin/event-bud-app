import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicComponent } from './public.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SigninComponent } from './signin/signin.component';



@NgModule({
  declarations: [
    PublicComponent,
    PageNotFoundComponent,
    SigninComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PublicModule { }
