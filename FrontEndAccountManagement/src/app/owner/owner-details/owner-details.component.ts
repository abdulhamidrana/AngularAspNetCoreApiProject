import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from './../../shared/services/repository.service';
import { Owner } from './../../_interfaces/owner.model';
import { Component, OnInit } from '@angular/core';

@Component({
  //selector: 'app-owner-details',
  templateUrl: './owner-details.component.html',
  styleUrls: ['./owner-details.component.css']
})
export class OwnerDetailsComponent implements OnInit {

  public owner: Owner;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router,
    private activateRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getOwnerDetails();
  }

  getOwnerDetails = () => {
    let id:string = this.activateRoute.snapshot.params['id'];
    let apiAddress: string = `api/owner/${id}/account`;
    
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.owner = res as Owner;
    },(error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

}
