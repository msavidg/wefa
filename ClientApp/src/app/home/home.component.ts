import { Component, Inject } from '@angular/core';
import { RequestsService } from '../services/requests.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  columnDefs = [
    { headerName: 'Filing Request Id', field: 'filingRequestId',  },
    { headerName: 'Filing Request', field: 'filingRequest' },
    { headerName: 'BaseFormIdString', field: 'baseFormIdString' }
  ];

  rowData: Request[];

  constructor(@Inject(RequestsService) private requestService) {
    let results: Observable<Request[]>;

    results = requestService.getRequests();

    results.subscribe((x) => {
      this.rowData = x;
    });
  }
}
