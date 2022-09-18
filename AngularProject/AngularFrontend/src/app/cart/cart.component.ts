import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { FormBuilder } from '@angular/forms';

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

  counts = this.cartService.itemsCount();


  constructor(private cartService: CartService,
    private formbuilder: FormBuilder) { }


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

  totalCost() {
    this.counts = this.counts;
    //this.items = this.items. ;
  }

  onPayment() {
    window.alert('Your Payment is processing...');
  }
  
  ngOnInit(): void {
  }

}
