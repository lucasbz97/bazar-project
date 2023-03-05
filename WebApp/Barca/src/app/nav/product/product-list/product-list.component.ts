import { Component, OnInit } from '@angular/core';
import { filter, Observable, of, Subscription } from 'rxjs';
import { CategoryService } from '../category.service';
import { Category } from '../models/category';
import { Product } from '../models/product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  constructor(private productService: ProductsService, private categoryService: CategoryService) { }
  
  Categories: Category[] = [];
  CategorySubscription?: Subscription;
  

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

  categoryObserver = {
    next: (data: Category[]) => {
      // this.Categories = [data[0]];
      // this.Categories[0].Products = [data[0].Products[0]];
      this.Categories = data;
    },
    error: (error: any) => { console.log(error) },
    complete: () => { console.log('product stream completed ') }
  }

  ngOnInit() {
    this.CategorySubscription = this.categoryService.getCategoryWithProducts().subscribe(this.categoryObserver);
    this.ProductSubscription = this.productService.getProducts().subscribe(this.productObserver);
  }

  trackBannerItem (index:any, item: Product) {
    return item.Id;
  }

  trackCategoryItem(index:any, item: Category) {
    return item.Id;
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
