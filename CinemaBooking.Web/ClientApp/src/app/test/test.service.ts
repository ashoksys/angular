import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MvTest } from './test.model';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';


@Injectable()
export class TestService {

  baseUrl: string = 'https://localhost:44365/';

  constructor(public http: HttpClient) {

  }

  getTestData(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'Bookings').map(response => {
      if (response) {
        return response;
      }
    })
  }

}
