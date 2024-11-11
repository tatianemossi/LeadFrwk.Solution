import { HttpClient, HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LeadsService } from './app.service';
import { pipe } from 'rxjs';

interface Lead {
  id: number;
  contactFirstName: string;
  createDate: Date;
  suburb: string;
  category: number;
  description: string;
  price: number;
  status: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  public leads: Lead[] = [];

  constructor(private http: HttpClient, private leadsService: LeadsService) { }

  ngOnInit() {
    this.getLeads();
  }

  getLeads() {
    this.leadsService.getAll().subscribe(
      (data) => this.leads = data,
      (error) => console.error('Erro ao carregar os dados', error));
  }

  changeStatusLead(id: number, status: number) {
    let result = this.leadsService.changeStatusLead(id, status);

    if(result == HttpStatusCode.Ok)
      console.log("SUCESSOOOO");
    else
      console.log("ERROOOUUUUU");
  }

  title = 'leadsfrwk.app.client';
}
