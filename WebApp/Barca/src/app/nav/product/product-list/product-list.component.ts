import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  constructor(private productService: ProductsService) {}

  public productLoaded: boolean = false;
  public productsBanner: Product [] = [];
  Products: Observable<Product[]>;

  ngOnInit() {
    this.Products = this.productService.getProducts();
    
    // this.Products.subscribe(data => {
    //   this.productsBanner = this.setProductsBanner(data);
    //   this.productLoaded = true;
    // }, error => {
    //   console.log(error);
    // })
  }

  setProductsBanner(products: Product[]): Product[] {
    var aux: Product[] = [];
    products.forEach((product) => {
      let prdExists = aux.find((prdAdd) => {
        return prdAdd.CategoryID == product.CategoryID;
      });

      if (!prdExists) {
        aux.push(product);
      }
    });
    return aux;
  }
}
