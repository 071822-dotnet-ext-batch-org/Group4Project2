import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { FormBuilder } from '@angular/forms';
import { Product } from '../products';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  template:`
  <table>
    <thread>
      <th>name</th>
      <th>price</th>
    </thread>
    <tbody>
      <tr *ngFor="let cost of app-cart">
        <td>{{cost.price}}</td>
      </tr>
    </tbody>
  <table>`
})
export class CartComponent implements OnInit {

  items = this.cartService.getItems();

<<<<<<< HEAD
  //counts = this.cartService.itemsCount();

  cartTotal: number = 0;
  products: Product[] = [];



  constructor(private cartService: CartService,
    private formbuilder: FormBuilder) {
      this.cartService.getTotalCartCost().subscribe(costTotal => this.cartTotal = costTotal);
    }
=======
  counts = this.cartService.itemsCount();


  constructor(private cartService: CartService,
    private formbuilder: FormBuilder) { }


>>>>>>> e39a28daf09db0c55117901cf6848d951252da8c
  checkoutForm = this.formbuilder.group({
    FirstName: '',
    LastName: '',
    DeliveryAddress: '',
  })

  onSubmit(): void {
    //Process checkout data here
    this.items = this.cartService.clearCart();
    console.warn('Your order has been submitted', this.checkoutForm.value);
    this.checkoutForm.reset();
  }

<<<<<<< HEAD
  totalCost(): void {
    this.cartService.totalCartCost;
    //this.items = this.items. ;
  }

  checkoutCart(): void {
    this.cartTotal = 0;
    this.products = [];
    this.cartService.updateCart(0);
  }
  onPayment() {
    window.alert('Your Payment is processing...');
  }
=======
  totalCost() {
    this.counts = this.counts;
    //this.items = this.items. ;
  }
>>>>>>> e39a28daf09db0c55117901cf6848d951252da8c

  ngOnInit(): void {
  }

}
