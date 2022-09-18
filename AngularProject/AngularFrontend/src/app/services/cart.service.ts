import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../products';
import { Observable, Subject } from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class CartService {

  private ourBookUrl = 'http://localhost:5010/DisplayAll?';

  items: Product[] = [];
  constructor(
    private http:HttpClient
  ) { }

  private cartTotal: Subject<number> = new Subject<number>();
  private cartBooks: Subject<number> = new Subject<number>();

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

<<<<<<< HEAD
  totalCartCost(costTotal: number){
    this.cartTotal.next(costTotal);
  }

  getTotalCartCost(): Observable<number>{
    return this.cartTotal.asObservable();
  }

  updateCart(items: number){
    this.cartBooks.next(items++);
  }

  getUpdatedCart(): Observable<number>{
    return this.cartBooks.asObservable();
  }

  getShippingPrices() {
    return this.http.get<{ type: string, price: number }[]>('/assets/shipping.json');
  }

=======
>>>>>>> e39a28daf09db0c55117901cf6848d951252da8c
}
