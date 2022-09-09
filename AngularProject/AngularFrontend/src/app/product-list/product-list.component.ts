import { Component, OnInit } from '@angular/core';
import { products } from '../products';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products = [...products];


  addToCart() {
    window.alert('The product has been added to the cart!');
  }

  onNotify() {
    window.alert('You will be notified when the product goes on sale');
  }
}