import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { ProductsService } from './nav/product/products.service';
import { AppRoutingModule } from './app-routing.module';
import { NavegacaoModule } from './nav/nav.module';
import { CategoryService } from './nav/product/category.service';
import { AuthenticationService } from './nav/authentication/authentication.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NavegacaoModule
  ],
  providers: [ProductsService, CategoryService, AuthenticationService,
    {provide: APP_BASE_HREF, useValue: '/'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
