import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { IamRoutingModule } from './iam-routing.module';

import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { SpinnerComponent } from '../../shared/components/spinner/spinner.component';


@NgModule({
  declarations: [
    SigninComponent,
    SignupComponent
  ],
  imports: [
    CommonModule,
    IamRoutingModule,
    ReactiveFormsModule,
    SpinnerComponent,
  ],
  exports: [
    SigninComponent,
    SignupComponent
  ]
})
export class IamModule { }
