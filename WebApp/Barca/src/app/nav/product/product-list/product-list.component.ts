import { Component, OnInit } from '@angular/core';
import { filter, Observable, of, Subscription } from 'rxjs';
import { Product } from '../models/product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  constructor(private productService: ProductsService) { }
  
  Products: Product[] = [];
  ProductSubscription?: Subscription;
  ProductsBanner: Product[] = [];

  productObserver = {
    next: (data: Product[]) => { 
      this.Products = data; 
      this.ProductsBanner = this.setProductsBanner(data);
    },
    error: (error: any) => { console.log(error) },
    complete: () => { console.log('product stream completed ') }
  }

  ngOnInit() {
    this.ProductSubscription = this.productService.getProducts().subscribe(this.productObserver);
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
