import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { MenuComponent } from './navigation/menu/menu.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { HomeComponent } from './home/home.component';
import { rootRouterConfig } from './config/app-routing.module';
import { ProductsService } from './products/products.service';
import { ProductListComponent } from './products/product-list/product-list.component';
import { FiltersComponent } from './filters/filters.component';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent,
    ProductListComponent,
    FiltersComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig, { useHash: false })],
    FormsModule
  ],
  providers: [ProductsService,
    {provide: APP_BASE_HREF, useValue: '/'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
