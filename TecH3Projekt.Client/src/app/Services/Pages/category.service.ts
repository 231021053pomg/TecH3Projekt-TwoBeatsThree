import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';//
import { catchError, tap } from 'rxjs/operators';//

import { Category } from 'src/app/Components/Domain';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl: string = "https://localhost:5001/api/type";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type' : 'application/json' })
  };

  constructor(
    private http:HttpClient 
  ) { }

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl);
  }

  getCategory(id:number): Observable<Category>{
    return this.http.get<Category>(`${this.apiUrl}/${id}`)
    .pipe(catchError(this.handleError<any>("GetOneCategory"))
    );
  }

  addCategory(category: Category): Observable<Category> {

    return this.http.post<Category>(this.apiUrl, category, this.httpOptions)
    .pipe(catchError(this.handleError<Category>("AddCategory"))
    );

  }

  updateCategory(id:number , category:Category): Observable<Category>{
    return this.http.put<Category>(`${this.apiUrl}/${id}`, category, this.httpOptions)
    .pipe(catchError(this.handleError<any>('updateCategory')));
  }

  deleteCategory(id:Number): Observable<Category>{
    return this.http.delete<Category>(`${this.apiUrl}/${id}`, this.httpOptions)
    .pipe(catchError(this.handleError<any>('deleteCategory'))
    );
  }

   /** USED FOR handleError.
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
