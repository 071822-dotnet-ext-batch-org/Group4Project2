import { Injectable } from '@angular/core';
import { Product } from '../products';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private ourBookUrl = 'http://localhost:5010/DisplayAll?bookName=%22The%20Hobbit%22';

  items: Product[] = [];

  constructor(
    private http: HttpClient) { }

  addToCart(product: Product) {
    this.items.push(product);
  }

  /*getItems(): Observable<Items[]> {
    return this.http.get<Items[]>(this.ourBookUrl)
    //return this.items;
  }*/

  getItems(){
    return this.items;
  }

  itemsCount(){
    return this.items.length;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

  getShippingPrices() {
    return this.http.get<{ type: string, price: number }[]>('/assets/shipping.json');
  }

}
