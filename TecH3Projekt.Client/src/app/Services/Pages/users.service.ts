import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';//
import { catchError, tap } from 'rxjs/operators';//

import { User } from 'src/app/Components/Domain';//Domain.ts file.
import { LogIn } from 'src/app/Components/Domain';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = "https://localhost:5001/api/user";//HOW TO RESOLVE???

  httpOptions = {
    headers: new HttpHeaders({ 'Content-User' : 'application/json' })
  };

  constructor(
    private http:HttpClient 
  ) { }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.apiUrl);
  }

  getLogIns(): Observable<LogIn[]>{
    return this.http.get<LogIn[]>(this.apiUrl);
  }

  getUser(id:number): Observable<User>{
    return this.http.get<User>(`${this.apiUrl}/${id}`)
    .pipe(catchError(this.handleError<any>("GetOneUser"))
    );
  }
//ADD ONLY ADMIN LOGIN.
  addLogin(login: LogIn): Observable<LogIn> {

    return this.http.post<LogIn>(this.apiUrl, login, this.httpOptions)
    .pipe(catchError(this.handleError<LogIn>("AddLogin"))
    );

  }

  addUser(user: User): Observable<User> {

    return this.http.post<User>(this.apiUrl, user, this.httpOptions)
    .pipe(catchError(this.handleError<User>("AddUser"))
    );

  }

  updateCategory(id:number , user:User): Observable<User>{
    return this.http.put<User>(`${this.apiUrl}/${id}`, user, this.httpOptions)
    .pipe(catchError(this.handleError<any>('updateUser')));
  }

  deleteUser(id:Number): Observable<User>{
    return this.http.delete<User>(`${this.apiUrl}/${id}`, this.httpOptions)
    .pipe(catchError(this.handleError<any>('deleteUser'))
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
