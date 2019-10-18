import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { throwError } from "rxjs/internal/observable/throwError";

@Injectable({
  providedIn: "root"
})
export class LogService {
  url_api: string = "https://localhost:5001/api/log/";

  constructor(private http: HttpClient) {}

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };

  getLatestLog() {
    return this.http.get(this.url_api + "latest");
  }

  getTodaysLogs() {
    return this.http.get(this.url_api + "today");
  }

  getThisWeeksLogs() {
    return this.http.get(this.url_api + "current-week");
  }

  getThisMonthsLogs() {
    return this.http.get(this.url_api + "current-month");
  }

  getAllSucceededLogs() {
    return this.http.get(this.url_api + "succeeded");
  }

  getAllFailedLogs() {
    return this.http.get(this.url_api + "failed");
  }

  getAllLogs() {
    return this.http.get(this.url_api + "all");
  }

  // Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error("An error occurred:", error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // return an observable with a user-facing error message
    return throwError("Something bad happened; please try again later.");
  }
}
