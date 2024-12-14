import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';  
import { AppComponent } from './app.component';
import { BookService } from './book.service'; 
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [BookService,provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
