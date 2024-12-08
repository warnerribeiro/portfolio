import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../interfaces/book';
import * as Config from '../config';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl: string = Config.urlApi + 'book/';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl);
  }

  get(id: number): Observable<Book> {
    const url = this.baseUrl + id;
    return this.http.get<Book>(url);
  }

  post(assunto: Book): Observable<Book> {
    return this.http.post<Book>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Book): Observable<Book> {
    const url = this.baseUrl + id;
    return this.http.put<Book>(url, assunto);
  }

  delete(id: number): Observable<any> {
    const url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
