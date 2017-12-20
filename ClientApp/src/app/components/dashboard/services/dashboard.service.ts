import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class DashboardService {
  private url = 'http://localhost:5050/api/sensors/';
  // private url = 'http://parktrack.ddns.net/api/sensors/';
  private adminToken = 'c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e';

  constructor(private http: Http) { }

  private headers: Headers = new Headers({
    'Accept' : 'application/json'
  });

  getAllSensors(): Observable<any> {
    return this.http.get(this.url + this.adminToken, {headers: this.headers})
      .map(response => <any>(<Response>response).json())
      .catch(this.handleError);
  }

  getSensorsByIdWithToken(sensorId, token) {
    const request = sensorId + '/' + token;
    console.log(request);
    return this.http.get(this.url + sensorId + '/' + token, {headers: this.headers})
      .map(response => <any>(<Response>response).json())
      .catch(this.handleError);
  }

  private handleError(error: any) {
    if (error.status === 500) {
      console.log('Error: 500' );
      return Observable.of(false);
    } else if (error.status === 400) {
      console.log('Error: 400' );
      return Observable.of(false);
    } else if (error.status === 409) {
      console.log('Error: 409' );
      return Observable.of(false);
    } else if (error.status === 406) {
      console.log('Error: 406' );
      return Observable.of(false);
    } else if (error.status === 404) {
      console.log('Error: 404 - page not found' );
      return Observable.of(false);
    }
  }


}
