import { Component, OnInit } from '@angular/core';
import { BookServiceService } from 'src/app/services/book-service.service';
import { AllBooks } from 'src/app/Models/AllBooks';
@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  allBooks? : AllBooks[] = [];

  constructor(private BSService: BookServiceService) { }

  ngOnInit(): void {
    this.getAllBooks()
  }
    getAllBooks(): void {
      //get request
      this.BSService.getAllBooks()
      .subscribe(allBooks => this.allBooks = allBooks);
    }
}
