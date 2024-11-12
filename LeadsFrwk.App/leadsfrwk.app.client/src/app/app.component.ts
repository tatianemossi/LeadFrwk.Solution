import { HttpClient, HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LeadsService } from './app.service';
import { pipe } from 'rxjs';
import { LeadStatusEnum } from './enums/leadStatusEnum';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { LeadCategoryEnum } from './enums/leadCategoryEnum';

interface Lead {
  id: number;
  contactFirstName: string;
  createDate: Date;
  suburb: string;
  category: number;
  description: string;
  price: number;
  status: number;
  phoneNumber: string;
  email: string;
  contactLastName: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  public leads: Lead[] = [];
  public leadsAccepteds: Lead[] = [];
  public config = new MatSnackBarConfig();
  public showLoader: boolean = false;
  public leadsAcceptedsExists: boolean = false;

  constructor(private http: HttpClient, private leadsService: LeadsService, private _snackBar: MatSnackBar) { }
  ngOnInit() {
    this.getLeads();
  }

  getLeads() {
    this.leadsService.getAll().subscribe((data) => {
      this.leads = data;
      this.leadsAccepteds = data.filter(x => x.status == 1);

      if (this.leadsAccepteds.length > 0)
        this.leadsAcceptedsExists = true;
    },
      (error) => console.error('Error loading results', error));
  }

  changeStatusLead(id: number, status: number, price: number, email: string) {
    this.showLoader = true;

    this.leadsService.changeStatusLead(id, status, price, email).subscribe((response) => {

      this._snackBar.open(response.message, '', {
        duration: 2000,
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
        panelClass: ['text-white']
      });

      setTimeout(() => { location.reload() }, 1500);
    });
  } 

  loadStatus(status: number) {
    if (status == LeadStatusEnum.Accepted)
      return "Accepted";

    if (status == LeadStatusEnum.Declined)
      return "Declined";

    return "Lead Invitation";
  }

  loadCategory(category: number) {
    if (category == LeadCategoryEnum.Artist)
      return "Artist";

    if (category == LeadCategoryEnum.InteriorPainters)
      return "Interior Painters";

    return "Painters";
  }

  title = 'leadsfrwk.app.client';
}
