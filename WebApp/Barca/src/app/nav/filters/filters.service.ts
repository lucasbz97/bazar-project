import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Filter } from '../filters/models/filter';

@Injectable({
  providedIn: 'root'
})
export class FiltersService {

  constructor(private http: HttpClient) { }

  protected subMenuFilters: Filter[] = [];
  protected UrlServiceV1: string = "http://localhost:3000/"

  getFilters(): Observable<Filter[]> {
      return this.http.get<Filter[]>(this.UrlServiceV1 + "filters");
  }
}
