import { Component, OnInit } from '@angular/core';
import { OrderServiceService } from 'src/app/services/order-service.service';
import { Orders } from 'src/app/Models/Orders';
import { FormControl,FormGroup } from '@angular/forms';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {

  orders?: Orders[] = [];
  constructor(private OSService: OrderServiceService) {}

  ngOnInit(): void {
    this.getOrders()
  }
    getOrders(): void {
      //get request
      this.OSService.getOrders()
      .subscribe(orders => {this.orders = orders;});
    }

}
