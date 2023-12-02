import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
  constructor(private http: HttpClient) {}

  create(payload: any): Observable<any> {
    return this.http.post(
      `${environment.BASE_URL_API}/user/question/create`,
      payload
    );
  }
}
