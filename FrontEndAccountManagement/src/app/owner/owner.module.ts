import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";


import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { OwnerCreateComponent } from './owner-create/owner-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OwnerUpdateComponent } from './owner-update/owner-update.component';
import { OwnerDeleteComponent } from './owner-delete/owner-delete.component';



@NgModule({

  imports: [
    CommonModule,    
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component:OwnerListComponent },
      { path: 'details/:id', component: OwnerDetailsComponent },
      { path: 'create', component:OwnerCreateComponent },
      { path: 'update/:id', component:OwnerUpdateComponent },
      { path: 'delete/:id', component: OwnerDeleteComponent }
    ]),
    SharedModule
  ],

  declarations: [
    OwnerListComponent, 
    OwnerDetailsComponent, 
    OwnerCreateComponent,
    OwnerUpdateComponent,
    OwnerDeleteComponent
  ]  
})
export class OwnerModule { }


//we don’t have providers array inside the owner module file. 
//That’s because we should register all the services in the 
//root module. That way components will inject the same instance 
//of the service only once and you can keep the state in your service.