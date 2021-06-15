import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';//
import { Observable, of } from 'rxjs';//
import { catchError, tap } from 'rxjs/operators';//

import { User } from 'src/app/Components/Domain';//Domain.ts file.

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = "https://localhost:5001/api/user";//CONFIRM USE.

  constructor(
    private http:HttpClient //CoNFIRM USE.
  ) { }

  getUser(): Observable<User[]>{
    return this.http.get<User[]>(this.apiUrl);// confirm suse.
  }

  //addUser(user: User): 
}
