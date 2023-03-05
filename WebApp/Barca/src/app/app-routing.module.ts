import { NgModule } from '@angular/core';
import { RouterModule, Routes, ExtraOptions } from '@angular/router';
import { AuthenticationAppComponent } from './nav/authentication/authentication.app.component';
import { AboutComponent } from './nav/company/about/about.component';
import { ContactComponent } from './nav/company/contact/contact.component';
import { HomeComponent } from './nav/home/home.component';
import { NotFoundComponent } from './nav/not-found/not-found.component';
import { ProductListComponent } from './nav/product/product-list/product-list.component';

const routerOptions: ExtraOptions = {
  scrollPositionRestoration: "enabled",
  anchorScrolling: "enabled",
  scrollOffset: [0, 64]
};

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent},
    { path: 'contato', component: ContactComponent},
    { path: 'sobre', component: AboutComponent},
    { path: 'products', component: ProductListComponent},
    { path: '404', component: NotFoundComponent},
    {
        path: '',
        loadChildren: () =>
          import('./nav/authentication/authentication.module').then((m) => m.AuthenticationModule),
    },
    {
      path: '',
      loadChildren: () =>
        import('./nav/product/product.module').then((m) => m.ProductModule),
    },
    { path: '**', redirectTo: '/404'}
];

@NgModule({
    imports: [RouterModule.forRoot(routes, routerOptions)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }