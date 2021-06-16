import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';//
import { catchError, tap } from 'rxjs/operators';//

import { User } from 'src/app/Components/Domain';//Domain.ts file.

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = "https://localhost:5001/api/user";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type' : 'application/json' })
  };

  constructor(
    private http:HttpClient 
  ) { }

  getUser(): Observable<User[]>{
    return this.http.get<User[]>(this.apiUrl);
  }

  addUser(user: User): Observable<User> {

    return this.http.post<User>(this.apiUrl, user, this.httpOptions)
    .pipe(catchError(this.handleError<User>("AddUser"))
    );

  }

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
