import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { convertToParamMap, Router } from '@angular/router';
import { RegistrationModel } from 'src/app/models/RegistrationModel';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  RegistrationModel:RegistrationModel=new RegistrationModel();
  public Countries:any=[];
  public States:any=[];
  public Districts:any=[];
  public cid:any='';
  public stateId:any='';
  public Email:any='';
  public isbtnFlag:boolean=false;
  public isemailFlag:boolean=false;
  public showLoader:boolean=false;
  public datetest:any;
  public dataOfDate:any='';
  public displayStyle = "none";
  public popupDisplayMsg:string='';
  public popupHeaderMsg:string='';
  public requestId:number=0;
  constructor(private _router:Router,private http:HttpClient,private _service:RegistrationService,public datepipe: DatePipe) { }

  ngOnInit(): void {
    this.getCountry();
    this.datetest=new Date();//'2022-11-04';
    this.dataOfDate=this.datepipe.transform(this.datetest, 'yyyy-MM-dd')
    console.log("date",this.dataOfDate);
    this.GetCustomerData();
   
  } 

  registrationCustomer(){
    this.showLoader=true;
    this.isemailFlag=false;
    console.log(this.RegistrationModel);
    var registrationData={
        CustomerAddress:this.RegistrationModel.CustomerAddress,
        CustomerCountry:this.RegistrationModel.CustomerCountry,
        CustomerPhoneNumber:this.RegistrationModel.CustomerPhoneNumber,
        CustomerPassword:this.RegistrationModel.CustomerPassword,
        CustomerPanCard:this.RegistrationModel.CustomerPanCard,
        CustomerName:this.RegistrationModel.CustomerName,
        CustomerEmail:this.RegistrationModel.CustomerEmail,
        CustomerDistrict:this.RegistrationModel.CustomerDistrict,
        CustomerDOB:this.RegistrationModel.CustomerDOB,
        CustomerState:this.RegistrationModel.CustomerState,
    }
    console.log("registrationData",registrationData);
    this._service.CustomerRegistration(registrationData).subscribe(res=>this.CustomerRegistrationSuccess(res),res=>console.log(res));

    
  }
  CustomerRegistrationSuccess(data:any){
    this.showLoader=false;
    console.log(data);
    if(data.token=='already'){
      this.isemailFlag=true;
    }else{
      this.popupHeaderMsg="";
    this.popupDisplayMsg="Dear Customer your registered successfully";
      this. openPopup(); 

    }
    
  }
  changeEmail(){
    this.isemailFlag=false;
  }
  getCountry(){
    this._service.GetCountryList().subscribe(res=>this.GetCountrySuccess(res),res=>console.log(res));
  }
  GetCountrySuccess(input:any){
    console.log("country data",input);
    this.Countries=input;
  }
  onchangeCountry(event:any){
    this.cid = event.target.value;
    if(this.cid!=''){
      this._service.GetStateList(this.cid).subscribe(res=>this.GetStateSuccess(res),res=>console.log(res));
    }else{
      this.States=null;
    }
    
  }
  GetStateSuccess(input:any){
    console.log("state data",input);
    this.States=input;
  }
  onchangeStates(event:any){
    this.stateId= event.target.value;
    if(this.stateId!=''){
      this._service.GetDistrictList(this.stateId).subscribe(res=>this.GetDistrictSuccess(res),res=>console.log(res));
    }else{
      this.Districts=null;
    }
  }
  GetDistrictSuccess(input:any){
    console.log("district", input);
    this.Districts=input;
  }
  GetCustomerData(){
    this.Email=localStorage.getItem('email');
    var data={
      Email:this.Email,
      Status:0
    }
    this._service.GetCustomerData(data).subscribe(res=>this.GetCustomerDataSuccess(res),res=>console.log(res));
  }
  GetCustomerDataSuccess(input:any){  
    this.isbtnFlag=true;
    console.log("update dataaaaaa",input);
    this.RegistrationModel.CustomerAddress=input.address;
    this.RegistrationModel.CustomerPhoneNumber=input.contactnumber;
    this.RegistrationModel.CustomerPassword=input.password;
    this.RegistrationModel.CustomerPanCard=input.pancard;
    this.RegistrationModel.CustomerName=input.customername;
    this.RegistrationModel.CustomerEmail=input.email;
    this.RegistrationModel.registrationId=input.registrationId;
    //this.RegistrationModel.CustomerCountry=input.cId;
    //this.RegistrationModel.CustomerDOB=input.dob;
    
  }
  UpdateCustomerProfile(){
    this.showLoader=true;
    console.log("update data",this.RegistrationModel);
    var updateData={
      registrationId:this.RegistrationModel.registrationId,
      CustomerAddress:this.RegistrationModel.CustomerAddress,
      CustomerCountry:this.RegistrationModel.CustomerCountry,
      CustomerPhoneNumber:this.RegistrationModel.CustomerPhoneNumber,
      CustomerPassword:this.RegistrationModel.CustomerPassword,
      CustomerPanCard:this.RegistrationModel.CustomerPanCard,
      CustomerName:this.RegistrationModel.CustomerName,
      CustomerEmail:this.RegistrationModel.CustomerEmail,
      CustomerDistrict:this.RegistrationModel.CustomerDistrict,
      CustomerDOB:this.RegistrationModel.CustomerDOB,
      CustomerState:this.RegistrationModel.CustomerState,
  }
  console.log("registrationData",updateData);
  this._service.UpdateCustomerProfile(updateData).subscribe(res=>this.UpdateCustomerProfileSuccess(res),res=>console.log(res));  
  }
  UpdateCustomerProfileSuccess(data:any){
    this.showLoader=false;
    this.isbtnFlag=false;
    this._router.navigate(['customer/servicerequest']);
  }
  closeUpdateCustomerProfile(){
    this._router.navigate(['customer/servicerequest']);
  }
  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
    this._router.navigate(['home/login']);
    
  }
}
