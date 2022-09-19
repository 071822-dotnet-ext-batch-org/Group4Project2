import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
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
  public cartTotal: Subject<number> = new Subject<number>();
  public cartBooks: Subject<number> = new Subject<number>();

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
  
  

}
