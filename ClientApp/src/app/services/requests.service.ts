import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import {Request} from '../models/request';

import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class RequestsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public  getRequests(): Observable<Request[]> {
    return this.http.get<Request[]>(this.baseUrl + 'api/FormData/GetRequests');
  }
}
