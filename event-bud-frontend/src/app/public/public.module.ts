import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SpinnerComponent } from "../shared/spinner/spinner.component";
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PublicComponent } from './public.component';
import { SigninComponent } from './signin/signin.component';



@NgModule({
    declarations: [
        PublicComponent,
        PageNotFoundComponent,
        SigninComponent
    ],
    imports: [
        CommonModule,
        SpinnerComponent
    ]
})
export class PublicModule { }
