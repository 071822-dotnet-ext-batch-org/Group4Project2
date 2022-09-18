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

  Orders!: any;
  orderTracker!: any;
  bookName!: any;
  getOrderTracker: any;

  constructor(private OSService: OrderServiceService) {}

  ngOnInit(): void {
    this.displayOrders()
  }
    displayOrders(): void {
      //get request
      this.OSService.getOrders()
      .subscribe((data: any) => {this.Orders=data;});
    }

    displayOrder(orderTracker: any): void {
      this.OSService = this.getOrderTracker(orderTracker).subscribe((data: any) => {
        this.bookName = data;
          console.log(this.bookName);
    })
  }
}
