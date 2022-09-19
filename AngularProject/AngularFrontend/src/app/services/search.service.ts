import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductInfoDto } from '../Models/ProductInfoDto';
import { HttpClient } from '@angular/common/http';
import { Product } from '../products';

@Injectable({
  providedIn: 'root'
})
export class ProductSearchService {

  items: Product[] = [];

  private ApiUrl = 'http://localhost:5010';

  //http object injected with apiUrl dependency
  constructor(private http: HttpClient) { }

  // Returns books by author
  public getAuthor(): Observable<ProductInfoDto> {
    return this.http.get<ProductInfoDto>(this.ApiUrl + "/Author")
  }


  // Get request returning title
  public getTitle(): Observable<ProductInfoDto> { //returns get request of observable
    return this.http.get<ProductInfoDto>(this.ApiUrl + "/title");
  }
}
