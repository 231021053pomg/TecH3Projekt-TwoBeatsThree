import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Product } from 'src/app/Components/Domain';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiUrl: string = "https://localhost:5001/api/product";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Product' : 'application/json' })
  };

  constructor(
    private http:HttpClient 
  ) { }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProductsByType(id:number): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.apiUrl}/category/${id}`);//NEED PROPER URL ???
  }

  getProduct(id:number): Observable<Product>{
    return this.http.get<Product>(`${this.apiUrl}/${id}`)
    .pipe(catchError(this.handleError<any>("GetOneProduct"))
    );
  }


  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product, this.httpOptions)
    .pipe(catchError(this.handleError<Product>("AddProduct"))
    );
  }

  
  updateProduct(id:number , product : Product): Observable<Product>{
    return this.http.put<Product>(`${this.apiUrl}/${id}`, product, this.httpOptions)
    .pipe(catchError(this.handleError<any>('updateProduct')));
  }


  deleteProduct(id:Number): Observable<Product>{
    return this.http.delete<Product>(`${this.apiUrl}/${id}`, this.httpOptions)
    .pipe(catchError(this.handleError<any>('deleteProduct'))
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
