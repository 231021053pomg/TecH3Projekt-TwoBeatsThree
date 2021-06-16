import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/Pages/users.service';
import { User } from '../../Domain';



@Component({
  selector: 'app-crudusers',
  templateUrl: './crudusers.component.html',
  styleUrls: ['./crudusers.component.css']
})
export class CRUDUsersComponent implements OnInit {

  users: User[] =[];

  constructor(
    private userService:UsersService
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers():void {
    this.userService.getUsers()
    .subscribe(users => this.users = users);
  }
//postNr needs to change for integer.
  add(firstName: string, lastName: string, address: string, postNr: any, city: string):void{
    this.userService.addUser({firstName, lastName, address, postNr, city} as User)
    .subscribe(user => {this.users.push(user) });
  }

}
