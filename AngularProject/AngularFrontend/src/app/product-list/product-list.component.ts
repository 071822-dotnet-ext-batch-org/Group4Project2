import { Component, OnInit } from '@angular/core';
import { products } from '../products';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})


export class ProductListComponent {

  products = [...products];

  constructor(public route: ActivatedRoute) { }


  addToCart() {
    window.alert('The product has been added to the cart!');
  }

  onNotify() {
    window.alert('You will be notified when the product is back in stock');
  }

  searchText: string = '';

  onSearchTextEntered(searchValue: string) {
    this.searchText = searchValue;
    console.log(this.searchText);
  }

  ngOnInit(): void {

  }
<<<<<<< HEAD
}
=======
}
>>>>>>> e39a28daf09db0c55117901cf6848d951252da8c
