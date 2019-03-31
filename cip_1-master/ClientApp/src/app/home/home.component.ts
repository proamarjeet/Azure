import { Component } from '@angular/core';
import { HttpClient, HttpHeaders, HttpXsrfTokenExtractor } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  title = 'Mine aktive sessioner';
  apiRoot = 'http://bc13-new.test.tdc.dk';

  constructor (private httpService: HttpClient, private http: Http) { }
  arrBirds: string [];
  arrUserGuides: string [];
  guideHeaders: any;
  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit () {
    this.httpService.get('./assets/birds.json').subscribe(
      data => {
        this.arrBirds = data as string [];	 // FILL THE ARRAY WITH DATA.
        //  console.log(this.arrBirds[1]);
      },
      (err: HttpErrorResponse) => {
        console.log (err.message);
      }
    );

    this.httpService.get('./assets/userGuides.json?$top=2').subscribe(
      data => {
        this.arrUserGuides = data as string[];
      },
      (err: HttpErrorResponse) => {
        console.log(err.message);
      }
    );

    this.guideHeaders = {
      Last_updated: 'Senest opdateret',
      Customer: 'Kunden',
      LID: 'LID',
      Area: 'Område',
      Guides: 'Guider'

    };
  }
  doGETWithHeaders() {
    console.log('GET WITH HEADERS');
    let headers = new Headers();
    headers.append('Content-Type', 'text/plain');
    headers.append('x-tdc-user-roles', 'CIP_PORTAL');
    //headers.append('Postman-Token', '92e8a64b-9579-47c6-a631-2860c59db9c3');
    headers.append('Authorization', 'Basic Y2lwX3Rlc3QwMDE6YWJjMTIz');
   // headers.append('SSOID', 'm32321');
   // headers.append('x-tdc-has-migrated-to-yspro', 'true');
 //   headers.append('x-tdc-username', 'm32321');
   
   // console.log(atob('Y2lwX3Rlc3QwMDE6YWJjMTIz'));
    let opts = new RequestOptions();
    opts.headers = headers;
    let url = `${this.apiRoot}/bc/secure/subscription?subscriptionId=87341127`;
    this.http.get(url, opts).subscribe(
      res => console.log(res.json()),
      msg => console.error(`Error: ${msg.status} ${msg.statusText}`)
    );
    
   
  }

 /* doGETWithHeaders1() {
    console.log('GET WITH HEADERS');
    let headers1 = new HttpHeaders();
    headers1 = headers1.set('Content-Type', 'text/plain').set('x-tdc-user-roles', 'CIP_PORTAL');
    
   // headers.append('Authorization', 'Basic Y2lwX3Rlc3QwMDE6YWJjMTIz');
   // headers.append('SSOID', 'm32321');
   // headers.append('x-tdc-has-migrated-to-yspro', 'true');
 //   headers.append('x-tdc-username', 'm32321');
   
   // console.log(atob('Y2lwX3Rlc3QwMDE6YWJjMTIz'));
    //let opts = new RequestOptions();
   // opts.headers = headers;
    let url = `${this.apiRoot}/bc/secure/subscription?subscriptionId=87341127`;
    
    this.httpService.get(url, {headers: headers1}).subscribe(
      res => console.log(res.json()),
      msg => console.error(`Error: ${msg.status} ${msg.statusText}`)
    );
  } */
}
