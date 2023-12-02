import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private http: HttpClient) {}

  create(payload: any): Observable<any> {
    return this.http.post(
      `${environment.BASE_URL_API}/user/contact/create`,
      payload
    );
  }
}
