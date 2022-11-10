import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {

  constructor(private _service:LoginService) { }

  public navitem1:any="";
  public navitem2:any="";
  ngOnInit(): void {
  }
  
  LoggedIn(Input:boolean):boolean{    
    if(Input){
      return this._service.logginIn();
    }
    else{
      return !this._service.logginIn();
    }
  }
  Logout(){
    debugger;
    this.navitem1="";
    this.navitem2="";
    this._service.logoutUser();
   
    
  }
  customerRoute(){
    this.navitem1="navitemSelect";
    this.navitem2="";
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('adminemail') 
  }
  adminRoute(){
    this.navitem1="";
    this.navitem2="navitemSelect";
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('adminemail') 
  }
  

}
