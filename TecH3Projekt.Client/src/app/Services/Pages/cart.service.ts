import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  subject = new Subject()

  constructor() { }

  sendToCart(product: any){

    this.subject.next(product) // trigger an event

  }

  getToCart(){
    return this.subject.asObservable()
  }
}
