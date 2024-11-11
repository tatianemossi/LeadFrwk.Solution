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

  changeStatusLead(id: number, status: number): any  {
    let body = {status}

    this.http.put<any>(this.apiUrl + id, status)
    .subscribe({
      next: data => {return data},
      error: error => {
          console.error('There was an error!', error);
      }
    }); 
  }
}
