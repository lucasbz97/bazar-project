import { Component, OnInit } from '@angular/core';
import { Filter } from '../filters/models/filter';

import { Product } from '../product/models/product';
import { ProductsService } from '../product/products.service';
import { FiltersService } from '../filters/filters.service';
import { CategoryService } from '../product/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  constructor(private productService: ProductsService,
              private filtersService: FiltersService,
              private categoryService: CategoryService) {}

  public products: Product[] = [];
  public filters: Filter[] = [];

  ngOnInit() {
  }
}
