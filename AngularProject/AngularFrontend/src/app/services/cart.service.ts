import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../products';
@Injectable({
  providedIn: 'root'
})
export class CartService {

  private ourBookUrl = 'http://localhost:5010/DisplayAll?';

  items: Product[] = [];
  constructor(
    private http:HttpClient
  ) { }

  addToCart(product: Product) {
    this.items.push(product);
  }

  getItems() {
    return this.items;
  }

  itemsCount(){
    return this.items.length;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

}
