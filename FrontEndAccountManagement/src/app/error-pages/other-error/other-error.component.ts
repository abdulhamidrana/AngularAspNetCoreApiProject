import { Component, OnInit } from '@angular/core';

@Component({
  //selector: 'app-other-error',
  templateUrl: './other-error.component.html',
  styleUrls: ['./other-error.component.css']
})
export class OtherErrorComponent implements OnInit {

  public errorMessage: string = 'Something unknown error occures! plz be patient...'

  constructor() { }

  ngOnInit(): void {
  }

}
