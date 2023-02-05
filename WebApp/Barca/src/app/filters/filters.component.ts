import { Component, OnInit } from '@angular/core';
import { Filter } from './models/filter';
import { FiltersService } from './filters.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {
  constructor(private filtersService: FiltersService ) {}

  public filters: Filter[] = [];

  ngOnInit() {
    this.filtersService.getFilters()
      .subscribe(
        data => {
          this.filters = data;
          console.log(data);
        },
        error => console.log(error)
      );
  }
}
