import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { FiltersComponent } from '../filters/filters.component';
import { ProductDetailComponent } from './components/product-detail/productDetail.component';
import { ProductRoutingModule } from './produto.route';
import { ProdutoAppComponent } from './product.app.component';

@NgModule({
  declarations: [
    ProductListComponent,
    FiltersComponent,
    ProductDetailComponent,
    ProdutoAppComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule
  ],
  exports:[
    ProductListComponent,
  ]
})
export class ProductModule { }
