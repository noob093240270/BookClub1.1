import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'http://localhost:5000/api/books';

  constructor(private http: HttpClient)
  { }

  getBooks(book: { title: string; author: string }): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);   //отправляется GET-запрос к серверу для получения списка книг
  }
  addBook(book: { title: string; author: string }): Observable<any> {
    return this.http.post(this.apiUrl, book);
  }
}
