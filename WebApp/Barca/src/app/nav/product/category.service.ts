import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constants } from 'src/constants';
import { Category } from './models/category';

@Injectable()
export class CategoryService {

  constructor(private http: HttpClient) { }

  protected UrlServiceV1: string = Constants.BARCA_API;

  getCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.UrlServiceV1 + "category");
  }

  getCategoryWithProducts(): Observable<Category[]> {
    return this.http.get<Category[]>(this.UrlServiceV1 + "category/withProducts");
  }
}
