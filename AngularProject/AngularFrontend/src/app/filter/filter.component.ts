import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  // Show number in (0) next to filter bubble
  @Input() all: number = 0
  @Input() author: number = 0;
  @Input() outStock: number = 0;
  @Input() inStock: number = 0;
}
