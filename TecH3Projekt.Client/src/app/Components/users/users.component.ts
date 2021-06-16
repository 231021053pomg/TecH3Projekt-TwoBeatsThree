import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/Pages/users.service';// 
import { User } from '../Domain';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  userFirstname: string = "Test";
  users: User[] = [];

  constructor(
    private userService:UsersService//ADDED for service
  ) { }

  ngOnInit(): void {

    this.getUsers();
  }

  getUsers(): void {
    this.userService.getUser()
    .subscribe(users => this.users = users);
  }

  add(firstName: string,lastName: string):void{

    this.userService.addUser({firstName, lastName} as User)
    .subscribe(user => {this.users.push(user) });

  }

}
