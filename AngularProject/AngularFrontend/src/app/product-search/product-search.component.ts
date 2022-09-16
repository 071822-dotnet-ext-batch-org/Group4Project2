//Import modules
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { SearchService } from './product-search.component.spec' ;
import { MatFormFieldModule } from '@angular/material/form-field';

//Add metadata components
@Component({
  selector: 'app-product-search', //Directive instance
  templateUrl: './product-search.component.html', // Connects to HTML view
  styleUrls: ['./product-search.component.css']// Connects to CSS connector
})
//Allows class to be exported and used in other modules
export class ProductSearchComponent implements OnInit {

  currentTitle: any; //Accepts and type
  constructor(private SS: SearchService) { }

  ngOnInit(): void {
  }
  enteredSearchValue: string = '';

  @Output()
  searchTextChanged: EventEmitter<string> = new EventEmitter<string>();

  onSearchTextChanged(){
    this.searchTextChanged.emit(this.enteredSearchValue)

  }

  displayTitle() {
    this.SS.getTitle().subscribe(data => {
      this.currentTitle = data;
    })
  }

}
