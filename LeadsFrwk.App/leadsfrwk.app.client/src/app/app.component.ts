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

  constructor(private http: HttpClient, private leadsService: LeadsService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getLeads();
  }

  getLeads() {
    this.leadsService.getAll().subscribe(
      (data) => {
        this.leads = data;
        this.leadsAccepteds = data.filter(x => x.status == 1);
      },
      (error) => console.error('Error loading results', error));
  }

  changeStatusLead(id: number, status: number, price: number) {
    let result = this.leadsService.changeStatusLead(id, status, price);

    if (result == HttpStatusCode.Ok) {
      this.openSnackBar("Status has not changed, please try again or contact to support");
    }
    else {
      this.showLoader = true;
      setTimeout(() => { location.reload() }, 3000);
      this.openSnackBar("Status changed successfully");
    }
  }

  openSnackBar(message: string) {
    this._snackBar.open(message);
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
