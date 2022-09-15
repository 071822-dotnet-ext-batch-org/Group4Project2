import { Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';


@NgModule({
  imports: [
    BrowserModule,
    //import HttpClientModule after BrowserModule
    HttpClientModule,
  ],
  // declarations: [
  //   AppComponent,
  // ],
  // bootstrap: [ AppComponent ]
})
export class AppModule { }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'OurBooks';
}


