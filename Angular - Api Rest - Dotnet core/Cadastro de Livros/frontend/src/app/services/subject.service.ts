import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Subject } from '../interfaces/subject';
import { Observable } from 'rxjs';
import * as Config from '../config';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  baseUrl: string = Config.urlApi + 'subject/';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.baseUrl);
  }

  get(id: number): Observable<Subject> {
    const url = this.baseUrl + id;
    return this.http.get<Subject>(url);
  }

  post(assunto: Subject): Observable<Subject> {
    return this.http.post<Subject>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Subject): Observable<Subject> {
    const url = this.baseUrl + id;
    return this.http.put<Subject>(url, assunto);
  }

  delete(id: number): Observable<any> {
    const url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
