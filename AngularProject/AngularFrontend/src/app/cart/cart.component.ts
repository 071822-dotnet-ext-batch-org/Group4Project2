import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { FormBuilder } from '@angular/forms';
import { Product } from '../products';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  // template:`
  // <table>
  //   <thread>
  //     <th>name</th>
  //     <th>price</th>
  //     <!-- <th>qty</th> -->
  //   </thread>
  //   <tbody>
  //     <tr *ngFor="let cost of app-cart">
  //       <td>{{items.price}}</td>
  //     </tr>
  //   </tbody>
  // <table>`
})
export class CartComponent implements OnInit {


  
  items = this.cartService.getItems();
  // products: Product[] = [];
  cartTotal = 114.98;

  // total = this.cartService.Total()
  
  


  constructor(private cartService: CartService,
    private formbuilder: FormBuilder) {}
// this.cartService.getTotalCartCost().subscribe(costTotal => this.cartTotal = costTotal); 

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

  totalCost(): void {
    this.cartService.totalCartCost;
    //this.items = this.items. ;
  }

  // checkoutCart(): void {
  //   this.cartTotal = 0;
  //   this.products = [];
  //   this.cartService.updateCart(0);
  // }

  onPayment() {
    window.alert('Your Payment is processing...');
  }

  // total(){
  //   this.BookItems.price * this.BookItems.price
  // }

  

  ngOnInit(): void {
  }

}


