import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './nav/company/about/about.component';
import { ContactComponent } from './nav/company/contact/contact.component';
import { HomeComponent } from './nav/home/home.component';
import { NotFoundComponent } from './nav/not-found/not-found.component';
import { ProductListComponent } from './nav/product/product-list/product-list.component';

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent},
    { path: 'contato', component: ContactComponent},
    { path: 'sobre', component: AboutComponent},
    { path: 'products', component: ProductListComponent},
    {path: '404', component: NotFoundComponent},
    {path: '**', redirectTo: '/404'}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }