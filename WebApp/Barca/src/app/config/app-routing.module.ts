import { Routes } from '@angular/router';
import { ContactComponent } from '../company/contact/contact.component';
import { AboutComponent } from '../company/about/about.component';
import { HomeComponent } from '../home/home.component';
import { ProductListComponent } from '../products/product-list/product-list.component';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import { NotFoundComponent } from '../not-found/not-found.component';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent},
    { path: 'contato', component: ContactComponent},
    { path: 'sobre', component: AboutComponent},
    { path: 'products', component: ProductListComponent},
    { path: 'login', component: LoginComponent},
    { path: 'registrar', component: RegisterComponent},
    {path: '404', component: NotFoundComponent},
    {path: '**', redirectTo: '/404'}
];