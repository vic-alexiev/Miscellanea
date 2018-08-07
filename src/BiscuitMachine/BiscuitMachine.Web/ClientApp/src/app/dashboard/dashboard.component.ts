import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard-component',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public state: string;

  private httpClient: HttpClient;
  private baseUrl: string;

  constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.state = '';
    this.httpClient = httpClient;
    this.baseUrl = baseUrl;
  }

  public switchOn() {
    this.httpClient.post<Response>(this.baseUrl + 'api/Dashboard/SwitchOn', null).subscribe(response => {
      this.addState(response.machineState);
    }, error => console.error(error));
  }

  public switchOff() {
    this.httpClient.post<Response>(this.baseUrl + 'api/Dashboard/SwitchOff', null).subscribe(response => {
      this.addState(response.machineState);
    }, error => console.error(error));
  }

  public pause() {
    this.httpClient.post<Response>(this.baseUrl + 'api/Dashboard/Pause', null).subscribe(response => {
      this.addState(response.machineState);
    }, error => console.error(error));
  }

  private addState(newState: string) {
    this.state += newState + '\r\n';
  }
}

interface Response {
  machineState: string;
}
