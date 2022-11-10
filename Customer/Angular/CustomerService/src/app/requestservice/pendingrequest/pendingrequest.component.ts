import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { GetServiceRequestDataModel } from 'src/app/models/GetServiceRequestDataModel';
import { PendingRequestModel } from 'src/app/models/PendingRequestModel';
import { CreaterequestService } from 'src/app/services/createrequest.service';
import { ExcelService } from 'src/app/services/excel.service';
import { PendingrequestService } from 'src/app/services/pendingrequest.service';

@Component({
  selector: 'app-pendingrequest',
  templateUrl: './pendingrequest.component.html',
  styleUrls: ['./pendingrequest.component.css']
})
export class PendingrequestComponent implements OnInit {
  PendingRequestModel:Array<PendingRequestModel>=new Array<PendingRequestModel>();
  GetServiceRequestDataModel:GetServiceRequestDataModel=new GetServiceRequestDataModel();
  constructor(private http:HttpClient,private _router:Router,private _service: PendingrequestService, private _serviceCreate: CreaterequestService,private excelService:ExcelService) { 
    
  }
  public navitem1:any="";
  public navitem2:any="";
  public navitem3:any="navitemSelect";
  public Email:any='';  
  isPeningRequest:boolean=true;
  isCloseRequest:boolean=false;
  isSearchRequest:boolean=false;
  isUpdateRequest:boolean=false;
  showLoader:boolean=false;
  showExcelLoader:boolean=false;

  public displayStyle = "none";
  public popupDisplayMsg:string='';
  public popupHeaderMsg:string='';
  public requestId:number=0;
  
  public mail:any='';
  public customerName='';

  public closePopflag:string='';
  
  ngOnInit(): void {
    this.GetPendingServiceRequest();   
  }



  navigateCreateRequest(){   
    this.navitem1='navitemSelect';
    this.navitem2='';
    this.navitem3='';
    this.isCloseRequest=false;
    this.isPeningRequest=false;
    this.isSearchRequest=false;
    this.isUpdateRequest=true;
    this.GetServiceRequestDataModel.isbtn=false;
    this.GetServiceRequestDataModel=new GetServiceRequestDataModel();
  }
  GetPendingServiceRequest(){   
    this.showLoader=true;
    this.Email=localStorage.getItem('email');
    var data={
      Email:this.Email,
      Status:1
    }
    this._service.GetPendingServiceRequestData(data).subscribe(res=>this.GetPendingServiceRequestSuccess(res),res=>console.log(res));
  }
  GetCloseServiceRequest(){
    this.navitem1='';
    this.navitem2='navitemSelect';
    this.navitem3='';
    this.showLoader=true;
    this.Email=localStorage.getItem('email');
    var data={
      Email:this.Email,
      Status:3
    }
    this._service.GetCloseServiceRequestData(data).subscribe(res=>this.GetCloseServiceRequestSuccess(res),res=>console.log(res));
  }
  GetPendingServiceRequestSuccess(data:any){   
    this.navitem1='';
    this.navitem2='';
    this.navitem3='navitemSelect';
console.log("pending data",data)
this.PendingRequestModel=data;
this.isPeningRequest=true;
 this.isCloseRequest=false;
 this.isSearchRequest=false;
 this.isUpdateRequest=false;
 this.showLoader=false;
 this.customerName=this.PendingRequestModel[0].cusromername;
  }
  GetCloseServiceRequestSuccess(data:any){
    this.showLoader=false;
    console.log("pending data",data)
    this.PendingRequestModel=data;
    this.customerName=this.PendingRequestModel[0].cusromername;
    this.isCloseRequest=true;
    this.isPeningRequest=false;
    this.isSearchRequest=false;
    this.isUpdateRequest=false;

  }
  navigatepeningRequest(){
    this.GetPendingServiceRequest();
  }
  searchDataSubmit(data:any){
    this.showLoader=true;
console.log("test", data);
this.Email=localStorage.getItem('email');
var postdata={
  Email:this.Email,
  Status:3,
  SearchId:data.searchid
}
this._service.SearchServiceRequestData(postdata).subscribe(res=>this.GetSearchIdSuccess(res),res=>console.log(res));
  }
  GetSearchIdSuccess(data:any){
    this.navitem1='';
    this.navitem2='navitemSelect';
    this.navitem3='';
    this.showLoader=false;
console.log("search data", data);
this.PendingRequestModel=data;
this.customerName=this.PendingRequestModel[0].cusromername;
this.isCloseRequest=false;
this.isPeningRequest=false;
this.isSearchRequest=true;
this.isUpdateRequest=false;
  }
  closegridReopen(srId:any){
    this.requestId=srId;
    this.showLoader=true;
    this._service.closegridReopenData(srId).subscribe(res=>this.GridChangeSuccess(res),res=>console.log(res));
    

  }
  closegridDelete(srId:any){
    this.requestId=srId;
    this.showLoader=true;
    this._service.closegridDelete(srId).subscribe(res=>this.GridDeleteSuccess(res),res=>console.log(res));
  }
  GridChangeSuccess(data:any){
    this.popupHeaderMsg="Service request Id: " +this.requestId;
    this.popupDisplayMsg="Service request reopen sucessfully";
   this.openPopup();
    this.showLoader=false;    
    this.closePopflag='closereopen';
  }
  GridDeleteSuccess(data:any){
    this.popupHeaderMsg="Service request Id: " +this.requestId;
    this.popupDisplayMsg="Service request delete sucessfully";
    this.openPopup();
    this.closePopflag='closerdelete';
    this.showLoader=false;  
  }
  pendinggridDelete(srId:any){
    this.requestId=srId;
    this._service.closegridDelete(srId).subscribe(res=>this.pendingGridDeleteSuccess(res),res=>console.log(res));
  }
  pendingGridDeleteSuccess(data:any){
    this.popupHeaderMsg="Service request Id: " +this.requestId;
    this.popupDisplayMsg="Service request delete sucessfully";
    this.openPopup();
    this.closePopflag='closereopen';
  }
  pendinggridEdit(srId:any){
    this.showLoader=true;
    this._service.GetServiceRequestData(srId).subscribe(res=>this.pendinggridEditSuccess(res),res=>console.log(res));
  }
  pendinggridEditSuccess(input:any){
    this.showLoader=false;
    this.GetServiceRequestDataModel.isbtn=true;
    //this.GetServiceRequestDataModel.category=input.category;
    this.GetServiceRequestDataModel.description=input.description;
    this.GetServiceRequestDataModel.srId=input.srId;
    this.GetServiceRequestDataModel.srcId=input.srcId;
    console.log("GetServiceRequestDataModel",this.GetServiceRequestDataModel);
    this.isCloseRequest=false;
    this.isPeningRequest=false;
    this.isSearchRequest=false;
    this.isUpdateRequest=true;

  }
  createRequestData(inputdata:any){  
    this.showLoader=true;  
    this.mail=localStorage.getItem('email');
    var createRequest={
      Email:this.mail,
      Categoty:inputdata.Categoty,
      Description:inputdata.Description
    }
    this._serviceCreate.CreateServiceRequest(createRequest).subscribe(res=>this.CreateServiceRequestSuccess(res),res=>console.log(res));
  }
  CreateServiceRequestSuccess(data:any){
    this.navitem1='';
    this.navitem2='';
    this.navitem3='navitemSelect';
    this.showLoader=false;
    this.GetPendingServiceRequest();
    this.GetServiceRequestDataModel.isbtn=false;
  }
  UpdateRequestData(data:any){
    this.showLoader=true;
    console.log("my",data);
    this.mail=localStorage.getItem('email');
    var createRequest={
      Email:this.mail,
      Categoty:data.Categoty,
      Description:data.Description,
      SrId:data.srId
    }
    this._serviceCreate.UpdateServiceRequest(createRequest).subscribe(res=>this.CreateServiceRequestSuccess(res),res=>console.log(res));
  }
  
  exportAsXLSX():void { 
    this.showExcelLoader=true;      
    this.Email=localStorage.getItem('email');
    var data={
      Email:this.Email,
      Status:0
    }
    this._service.GetAllServiceRequestData(data).subscribe(res=>this.GetAllServiceRequestSuccess(res),res=>console.log(res));
 }  
 public getJSON() {    
   return this.PendingRequestModel;
 }  
 GetAllServiceRequestSuccess(input:any){
  this.PendingRequestModel=input;
  this.excelService.exportAsExcelFile(this.PendingRequestModel, 'servicerequestdata'); 
  this.showExcelLoader=false;
 }
 UpdateProfile(){
  this._router.navigate(['home/registration']);
 }
 openPopup() {
  this.displayStyle = "block";
 
}
closePopup() {
  this.displayStyle = "none";
  if( this.closePopflag=='closereopen'){
    this.GetPendingServiceRequest();
  }else if (this.closePopflag=='closerdelete') {
    this. GetCloseServiceRequest();
  } else {
    
  }
}
}
