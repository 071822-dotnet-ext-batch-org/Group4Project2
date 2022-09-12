//Import modules
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

//Add metadata components
@Component({
  selector: 'app-product-search', //Directive instance
  templateUrl: './product-search.component.html', // Connects to HTML view
  styleUrls: ['./product-search.component.css']// Connects to CSS connector
})
//Allows class to be exported and used in other modules
export class ProductSearchComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  enteredSearchValue: string = '';

  @Output()
  searchTextChanged: EventEmitter<string> = new EventEmitter<string>();

  onSearchTextChanged(){
    this.searchTextChanged.emit(this.enteredSearchValue)

  }
}
