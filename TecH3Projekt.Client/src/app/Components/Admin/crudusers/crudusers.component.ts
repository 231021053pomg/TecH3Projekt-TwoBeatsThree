import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/Pages/users.service';
import { LogIn, User } from '../../Domain';



@Component({
  selector: 'app-crudusers',
  templateUrl: './crudusers.component.html',
  styleUrls: ['./crudusers.component.css']
})
export class CRUDUsersComponent implements OnInit {

  users: User[] =[];
  logins: LogIn[] =[];

  constructor(
    private userService:UsersService
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers():void {
    this.userService.getUsers()
    .subscribe(users => this.users = users);
    this.userService.getLogIns()
    .subscribe(logins => this.logins = logins);
  }

  //ADD LOGIN ONLY
  addAdmin(email: string, password: string):void{
    this.userService.addLogin({email, password} as LogIn)
    .subscribe(login => {this.logins.push(login) });
  }

//postNr needs to change for integer.
  add(firstName: string, lastName: string, address: string, postNr: any, city: string):void{
    this.userService.addUser({firstName, lastName, address, postNr, city} as User)
    .subscribe(user => {this.users.push(user) });
  }

  delete(user:User):void {

    if(confirm(`Confirm delete: ${user.firstName} ?`)) {
      
      this.users = this.users.filter(a => a !== user);//remove deleted user from getlist.
      this.userService.deleteUser(user.id).subscribe();

    }

  }

}
