import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  constructor(private productService: ProductsService) {}

  public products: Product[] = [];

  ngOnInit() {
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
