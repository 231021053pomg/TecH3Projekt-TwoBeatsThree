import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';//
import { catchError, tap } from 'rxjs/operators';//

import { LogIn } from 'src/app/Components/Domain';
import { User } from 'src/app/Components/Domain';


@Injectable({
  providedIn: 'root'
})
export class OpretKundeService {
  apiUrl: string = "https://localhost:5001/api/logIn";

  httpOptions = {
    Headers: new HttpHeaders({ 'Content-Opret' : 'application/json'})
  };

  constructor(
    private http:HttpClient
  ) { }

  // addLogIn(login: LogIn): Observable<LogIn> {
  //   return this.http.post<LogIn>(this.apiUrl, login, this.httpOptions)
  //   .pipe(catchError(this.handleError<any>('addLogin')));
  // }

   /**
      * Handle Http operation that failed.
      * Let the app continue.
      * @param operation - name of the operation that failed
      * @param result - optional value to return as the observable result
      */
    private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead

        // TODO: better job of transforming error for user consumption
        console.log(`${operation} failed: ${error.message}`);//console to this

        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
  }
  
}
