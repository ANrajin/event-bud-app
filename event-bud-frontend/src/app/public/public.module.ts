import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PublicRoutingModule } from './public-routing.module';
import { PublicComponent } from './public.component';
import { IamModule } from './iam/iam.module';



@NgModule({
    declarations: [
        PublicComponent,
        PageNotFoundComponent,
    ],
    imports: [
        CommonModule,
        PublicRoutingModule,
        IamModule
    ]
})
export class PublicModule { }
