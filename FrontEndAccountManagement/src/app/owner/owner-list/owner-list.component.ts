import { Component, OnInit } from '@angular/core';
import { RepositoryService } from "./../../shared/services/repository.service";
import { Owner } from "./../../_interfaces/owner.model";
import { ErrorHandlerService } from "./../../shared/services/error-handler.service";
import { Router } from "@angular/router";

@Component({
  //selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {

  public errorMessage: string = '';
  public owners: Owner[];

  constructor(private repository: RepositoryService, 
    private errorHandler: ErrorHandlerService,
    private router:Router ) { }

  ngOnInit(): void {
    this.getAllOwners();
  }

  public getAllOwners = () => {
    let apiAddress: string = "api/owner";
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.owners = res as Owner[];
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public getOwnerDetails = (id) => {
    const detailsUrl: string = `/owner/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public redirectToUpdatePage = (id) => {
    const updateUrl: string = `/owner/update/${id}`;
    this.router.navigate([updateUrl]);
  }

  public redirectToDeletePage = (id) => {
    const deleteUrl: string = `/owner/delete/${id}`;
    this.router.navigate([deleteUrl]);
  }
  
}
