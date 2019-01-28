import { Component, OnInit } from '@angular/core';
import { TestService } from './test.service';

@Component({
    selector: 'app-test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.scss']
})
/** test component*/
export class TestComponent implements OnInit {

  testData:any;
    /** test ctor */
    constructor(public ts:TestService) {

  }

    ngOnInit(): void {
      this.ts.getTestData().subscribe(response => {
        this.testData = response;
        console.log("TEST DATA", response);
      })
    }

}
