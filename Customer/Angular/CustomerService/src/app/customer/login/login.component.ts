import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { AdminService } from 'src/app/services/admin.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public formdata:any;
  public customermail:any='';
  public showLoader:boolean=false;
  public url:any;
  public pageUrl:any='';
  public adminmail:any='';
  public signupmsg:any='';
  public displayStyle = "none";
  public popupDisplayMsg:string='';
  public popupHeaderMsg:string='';
  public requestId:number=0;
  public isemailLogin:boolean=false;
  constructor(private _router:Router,private _service:LoginService,private _adminservice:AdminService) { }

  ngOnInit(): void {
    this.displayStyle = "none";
    this.formdata = new FormGroup({
      email: new FormControl('',Validators.compose([Validators.required,Validators.email])),
      password: new FormControl('',Validators.compose([Validators.required,Validators.pattern("[0-9]+")]))
   });
  
  }

  UserModel:UserModel=new UserModel();

  onClickLoginSubmit(data:any){
    debugger;
    this.pageUrl=window.location.href.split("/",5);
    if(this.pageUrl[3]=="admin"){
      this.showLoader=true;
      console.log("login admin", data);
      this.adminmail=data.email;
      this._adminservice.AdmionLoginService(data).subscribe(res=>this.AdminLoginSuccess(res),res=>console.log(res));
    }else{
      this.showLoader=true;
      console.log("login customer", data);
      this.customermail=data.email;
      this._service.CustomerLogin(data).subscribe(res=>this.CustomerLoginSuccess(res),res=>console.log(res));
    }
   
  }
  CustomerLoginSuccess(input:any){
    console.log(input);
    if(input.val!="wrong"){
      this.isemailLogin=false;
      this.popupHeaderMsg="Customer email id: " + this.customermail;
      this.popupDisplayMsg="Dear Customer your login successfully";
      this.openPopup();
      localStorage.setItem('token',input.token);
      localStorage.setItem('email',this.customermail)  
      this.showLoader=false; 
    }
    else{
      this.isemailLogin=true;
      this.showLoader=false;
    }
     
     
  }
  AdminLoginSuccess(data:any){
    console.log(data);
    if(data.val!="wrong"){
      this.isemailLogin=false;
      this.showLoader=true;
      this.popupHeaderMsg="Admin email id: " +this.adminmail;
      this.popupDisplayMsg="Dear Admin your login successfully";
      this.openPopup();
      localStorage.setItem('token',data.token);
      localStorage.setItem('adminemail',this.adminmail)  
    }
    else{
      this.isemailLogin=true;
      this.showLoader=false;
    }
    
    
  }
  navigateRegister(){
   
    this.pageUrl=window.location.href.split("/",5);
    if(this.pageUrl[3]=="admin"){
      alert("Register not available. You should request to credentials");
    }else{
      this._router.navigate(['home/registration']);
    }
  }
  changeLoginEmail(){
    this.isemailLogin=false;
  }
  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
   this.pageUrl=window.location.href.split("/",5);
    if(this.pageUrl[3]=="admin"){
      this._router.navigate(['admin/grid']);
    }else{
      this._router.navigate(['customer/servicerequest']);
    }
  }
}
