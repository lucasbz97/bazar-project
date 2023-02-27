import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { FiltersComponent } from '../filters/filters.component';



@NgModule({
  declarations: [
    ProductListComponent,
    FiltersComponent,
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ProductListComponent
  ]
})
export class ProductModule { }
