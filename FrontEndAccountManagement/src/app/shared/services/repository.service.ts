import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getData = (route: string) => {
    return this.http.get(this.createCompleteRoute(this.envUrl.urlAddress, route));
  }
  
  public create = (route: string, body) => {
    return this.http.post(this.createCompleteRoute(this.envUrl.urlAddress, route), body, this.generateHeaders());
  }

  public update = (route: string, body) => {
    return this.http.put(this.createCompleteRoute(this.envUrl.urlAddress, route), body, this.generateHeaders());
  }

  public delete = (route: string) => {
    return this.http.delete(this.createCompleteRoute(this.envUrl.urlAddress, route));
  }


  private createCompleteRoute = (envAddress: string, route: string) => {
    return `${envAddress}/${route}`
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders ({'Content-Type': 'application/json'})
    }
  }

}
