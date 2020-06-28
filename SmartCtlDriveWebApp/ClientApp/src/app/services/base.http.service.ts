import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class BaseService {
  constructor(public http: HttpClient) {
  }
  apiBase = 'http://localhost:59801';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': this.apiBase
    }),
    withCredentials: false
  };
}
