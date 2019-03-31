import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public subscriptions: any[];
  title = 'Mine aktive sessioner';
  arrUserGuides: string [];
  guideHeaders: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      // this.forecasts = result;
    }, error => console.error(error));


    http.get<any[]>(baseUrl + 'api/SampleData/GetSubscriptions').subscribe(result => {
      console.log('Inside GetSubscriptions');
      console.log(result);
     // this.forecasts = result;

    }, error => console.error(error));

    this.guideHeaders = {
      Last_updated: 'Senest opdateret',
      Customer: 'Kunden',
      LID: 'LID',
      Area: 'Område',
      Guides: 'Guider'
    };

    http.get<any[]>(baseUrl + 'api/SampleData/GetActveUserGuides').subscribe(result => {
      console.log('Inside GetActveUserGuides');
      console.log(result);
      this.arrUserGuides = result;
     // this.forecasts = result;

    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
