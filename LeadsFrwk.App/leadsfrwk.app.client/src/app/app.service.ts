import { HttpClient, HttpStatusCode } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LeadsService {

  public apiUrl: string = `https://localhost:7217/api/Leads/`;

  constructor(protected injector: Injector, protected http: HttpClient) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  changeStatusLead(id: number, status: number, price: number, email: string): Observable<any> {
    let body = { status, price, email }

    return this.http.put<any>(this.apiUrl + id, body);
  }
}
