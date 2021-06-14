import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/Pages/users.service';// 

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  userFirstname: string = "Test";
  users: string[] = [];

  constructor(
    private userService:UsersService//ADDED for service
  ) { }

  ngOnInit(): void {

    this.users.push("Benny");
    this.users.push("Carl");
    console.log(this.users);
  }

  add(firstName: string,lastName: string):void{
    //this.userFirstname = firstName;
  }

}
