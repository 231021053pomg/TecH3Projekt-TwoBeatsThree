import { Component, OnInit } from '@angular/core';
import { OpretKundeService } from 'src/app/Services/Pages/opret-kunde.service';
import { UsersService } from 'src/app/Services/Pages/users.service';
import { LogIn, User } from '../../Domain';

@Component({
  selector: 'app-opret-kunde',
  templateUrl: './opret-kunde.component.html',
  styleUrls: ['./opret-kunde.component.css']
})
export class OpretKundeComponent implements OnInit {

  //logins: LogIn[] =[];

  constructor(
    private opretService:OpretKundeService,
    private userService:UsersService
  ) { }

  ngOnInit(): void {
  }

  // addLogIn(email: string, password: string, firstName: string, lastName: string, address:string, postNr: any, city: string ):void{
  //   this.opretService.addLogIn({email, password,firstName,lastName, address, postNr, city } as LogIn)
  //   .subscribe(login => {this.logins.push(login) });
  // }

}
