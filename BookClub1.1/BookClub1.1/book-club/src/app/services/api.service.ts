import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private baseUrl = 'http://localhost:5000/api';

    constructor(private http: HttpClient) {}

    getBooks() {
        return this.http.get(`${this.baseUrl}/books`);
    }

    addReadBook(userId: number, bookId: number) {
        return this.http.post(`${this.baseUrl}/readbooks`, { userId, bookId });
    }

    getReadBooks(userId: number) {
        return this.http.get(`${this.baseUrl}/readbooks/${userId}`);
    }

    removeReadBook(id: number) {
        return this.http.delete(`${this.baseUrl}/readbooks/${id}`);
    }
}
