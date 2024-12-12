import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookService } from './book.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  books: any[] = []; // массив
  constructor(private bookService: BookService) { }
  ngOnInit(): void {
    this.bookService.getBooks({ title: 'Book One', author: 'Author One' }).subscribe((data) => {
      this.books = data;
    });
  }
}
