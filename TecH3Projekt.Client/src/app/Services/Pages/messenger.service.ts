import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';   //Lissen and trigger mechanism

import { Product } from 'src/app/Components/Domain';

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject(); //instance of the Object

  constructor() { }



  sendMsg(product: Product) {
    this.subject.next(product) //Triggaring an event
  }

  getMsg() {
    return this.subject.asObservable() //anyone can subscribe whatever is triggered in sendMsg
  }

}
