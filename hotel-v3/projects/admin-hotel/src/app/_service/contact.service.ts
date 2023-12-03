import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../environments/environment.development";

@Injectable({
    providedIn: "root",
})
export class ContactService {
    constructor(private http: HttpClient) {}

    getAllContact(payload: any): Observable<any> {
        return this.http.post(
            `${environment.BASE_URL_API}/v2/admin/contact/get-all-contact`,
            payload
        );
    }

    getAllQuestion(payload: any): Observable<any> {
        return this.http.post(
            `${environment.BASE_URL_API}/v2/admin/contact/get-all-question`,
            payload
        );
    }
}

