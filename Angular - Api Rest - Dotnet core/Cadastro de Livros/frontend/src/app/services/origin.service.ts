import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Origin } from '../interfaces/origin';
import * as Config from '../config';

@Injectable({
  providedIn: 'root'
})
export class OriginService {
  baseUrl: string = Config.urlApi + 'originpurchase/';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Origin[]> {
    return this.http.get<Origin[]>(this.baseUrl);
  }

  get(id: number): Observable<Origin> {
    const url = this.baseUrl + id;
    return this.http.get<Origin>(url);
  }

  post(assunto: Origin): Observable<Origin> {
    return this.http.post<Origin>(this.baseUrl, assunto);
  }

  put(id: number, assunto: Origin): Observable<Origin> {
    const url = this.baseUrl + id;
    return this.http.put<Origin>(url, assunto);
  }

  delete(id: number): Observable<any> {
    const url: string = this.baseUrl + id;
    return this.http.delete(url);
  }
}
