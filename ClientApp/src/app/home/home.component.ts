import { Component, Inject } from '@angular/core';
import { RequestsService } from '../services/requests.service';
import { Observable } from 'rxjs';

let dateFormat = require('../../../node_modules/dateformat/lib');

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

  columnDefs = [
    { headerName: 'Filing Request Id', field: 'filingRequestId', hide: 'true' },
    { headerName: 'Filing Request', field: 'filingRequest' },
    { headerName: 'Filing Request Status', field: 'filingRequestStatus', filter: 'agSetColumnFilter', supressMenu: 'true' },
    { headerName: 'BaseFormIdString', field: 'baseFormIdString' },
    { headerName: 'Edition Date', field: 'editionDate', valueFormatter: params => { const d = new Date(params.value); return dateFormat(d, 'mm/yy'); } },
    { headerName: 'Document Type', field: 'documentType' },
    { headerName: 'Policy Class', field: 'policyClass' },
    { headerName: 'Policy Type', field: 'policyType' },
    { headerName: 'Short Name', field: 'shortName' },
    { headerName: 'Name', field: 'name' },
    { headerName: 'frsName', field: 'replacesExisitingForm' },
    { headerName: 'Replaces Existing Form', field: 'replacesExistingForm', cellRenderer: params => this.foo(params) },
    { headerName: 'Replaces Existing Form Name', field: 'replacesExistingFormName' },
    { headerName: 'Replaces Existing Form Edition Date', field: 'replacesExistingFormEditionDate' }
  ];

  rowData: Request[];

  constructor(@Inject(RequestsService) private requestService) {
    let results: Observable<Request[]>;

    results = requestService.getRequests();

    results.subscribe((x) => {
      this.rowData = x;
    });
  }

  public foo (params): String {
    return `<input type='checkbox' ${params.value ? 'checked' : 'true'} />`;
  }
}
