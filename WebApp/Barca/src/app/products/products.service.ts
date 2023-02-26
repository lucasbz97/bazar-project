import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from "./models/product";
import{ Constants } from './../../constants';

@Injectable()
export class ProductsService {

  constructor(private http: HttpClient) { }

  protected UrlServiceV1: string = Constants.BARCA_API;

  getProducts(): Observable<Product[]> {
      return this.http.get<Product[]>(this.UrlServiceV1 + "product");
  }
}
