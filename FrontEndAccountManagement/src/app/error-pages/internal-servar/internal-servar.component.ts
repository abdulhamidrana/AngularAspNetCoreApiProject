import { Component, OnInit } from '@angular/core';

@Component({
  //selector: 'app-internal-servar',
  templateUrl: './internal-servar.component.html',
  styleUrls: ['./internal-servar.component.css']
})
export class InternalServarComponent implements OnInit {

  public errorMessage: string = "500 Server Error, Contact Administrator!!!";

  constructor() { }

  ngOnInit(): void {
  }
}
