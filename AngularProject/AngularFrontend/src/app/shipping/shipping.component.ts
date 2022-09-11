import { Component, OnInit } from '@angular/core';
//import { Observable } from 'rxjs';
import { CartService } from '../services/cart.service';



@Component({
  selector: 'app-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.css']
})
export class ShippingComponent implements OnInit {

  shippingCosts = this.cartService.getShippingPrices();

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

}
