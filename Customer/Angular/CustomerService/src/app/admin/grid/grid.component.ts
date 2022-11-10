import { Component, OnInit } from '@angular/core';
import { PendingRequestModel } from 'src/app/models/PendingRequestModel';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  PendingRequestModel:Array<PendingRequestModel>=new Array<PendingRequestModel>();
  public Email:any='';
  public showLoader:boolean=false;
  public displayStyle = "none";
  public popupDisplayMsg:string='';
  public popupHeaderMsg:string='';
  public requestId:number=0;
  constructor(private _service:AdminService) { }

  ngOnInit(): void {
    this.displayStyle = "none";
    this.GetAdminData();
  }
  GetAdminData(){
    this.showLoader=true;
    this.Email=localStorage.getItem('adminemail');
    var data={
      Email:this.Email,
      Status:1
    }
    this._service.AdmionDataService(data).subscribe(res=>this.AdmionDataServiceSuccess(res),res=>console.log(res));
  }
  AdmionDataServiceSuccess(data:any){
    this.showLoader=false;;
    this.PendingRequestModel=data;
  }
  approveGrid(id:any){
    this.requestId=id;
    this._service.ApproveService(id).subscribe(res=>this.ApproveServiceSuccess(res),res=>console.log(res));
  }
  ApproveServiceSuccess(data:any){
    this.popupHeaderMsg="Service request Id: " +this.requestId;
    this.popupDisplayMsg="Service request approved sucessfully";
    this.openPopup();
    this.GetAdminData();
  }
  rejectGrid(id:any){
    this.requestId=id;
    this._service.RejectService(id).subscribe(res=>this.RejectServiceSuccess(res),res=>console.log(res));
  }
  RejectServiceSuccess(data:any){
    this.popupHeaderMsg="Service request Id: " +this.requestId;
    this.popupDisplayMsg="Service request rejected sucessfully";
    this.openPopup();
    this.GetAdminData();
  }
 
  
  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
  }

}
