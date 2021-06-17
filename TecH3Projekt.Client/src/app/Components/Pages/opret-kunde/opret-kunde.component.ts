import { Component, OnInit } from '@angular/core';
import { OpretKundeService } from 'src/app/Services/Pages/opret-kunde.service';
import { LogIn, User } from '../../Domain';

@Component({
  selector: 'app-opret-kunde',
  templateUrl: './opret-kunde.component.html',
  styleUrls: ['./opret-kunde.component.css']
})
export class OpretKundeComponent implements OnInit {

  logins: LogIn[] =[];

  constructor(
    private opretService:OpretKundeService
  ) { }

  ngOnInit(): void {
  }

  // addLogIn(email: string, password: string):void{
  //   this.opretService.addLogIn({email, password} as LogIn)
  //   .subscribe(login => {this.logins.push(login) });
  // }

  // addUser(firstName: string, lastName: string, address: string, postNr: any, city: string):void{
  //   this.opretService.addUser({firstName, lastName, address, postNr, city} as User)
  //   .subscribe(user => {this.users.push(user) });
  // }

}
