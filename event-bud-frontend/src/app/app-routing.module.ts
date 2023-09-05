import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';
import { SigninComponent } from './public/signin/signin.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent
  },
  {
    path: AppRoutes.Admin,
    component: AdminComponent,
    loadChildren: () => import('./admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: AppRoutes.Signin,
    component: SigninComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules,
    // enableTracing: true,
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
