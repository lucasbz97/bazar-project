import { Component, OnInit } from '@angular/core';
import { Filter } from '../filters/models/filter';
import { FiltersService } from '../filters/filters.service';
import { Product } from '../products/models/product';
import { ProductsService } from '../products/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  constructor(private productService: ProductsService, private filtersService: FiltersService) {}

  public products: Product[] = [];
  public filters: Filter[] = [];

  ngOnInit() {
    this.getProducts();
    this.getFilters();
  }

  protected getFilters() {
    this.filtersService.getFilters()
      .subscribe(
        data => {
          this.filters = data;
          console.log(data);
        },
        error => console.log(error)
      );
  }

  protected getProducts() {
    this.productService.getProducts()
      .subscribe(
        data => {
          this.products = data;
          console.log(data);
        },
        error => console.log(error)
      );
    }
  }