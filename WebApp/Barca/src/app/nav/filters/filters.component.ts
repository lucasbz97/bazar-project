import { Component, OnInit } from '@angular/core';
import { Filter } from '../filters/models/filter';
import { FiltersService } from './filters.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit {
  constructor(private filtersService: FiltersService ) {}

  public filters: Filter[] = [
    { 'id': "1", 'name': "Masculino"},
    { 'id': "2", 'name': "Feminino"},
    { 'id': "3", 'name': "Infantil"},
    { 'id': "4", 'name': "Utensilios"},
  ];

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
