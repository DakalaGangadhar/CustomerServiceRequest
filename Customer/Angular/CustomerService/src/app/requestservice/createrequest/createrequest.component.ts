import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreatRequest } from 'src/app/models/CreatRequest';
import { CreaterequestService } from 'src/app/services/createrequest.service';

@Component({
  selector: 'app-createrequest',
  templateUrl: './createrequest.component.html',
  styleUrls: ['./createrequest.component.css']
})
export class CreaterequestComponent implements OnInit {

  constructor(private _router:Router,private _service: CreaterequestService) { }
  public formdata:any;
  public mail:any='';
  public ServiceRequestDropDown:any=[];
  gridData={};
  public isbtn:boolean=false;
  CreatRequest:CreatRequest=new CreatRequest();
  ngOnInit(): void {
    this.GetServiceRequestCategoryDropDownData();

  }
 
  GetServiceRequestCategoryDropDownData(){
    this._service.GetCreaterequestServiceDropDownList().subscribe(res=>this.GetServiceRequestCategoryDropDownSuccess(res),res=>console.log(res));
  }
  GetServiceRequestCategoryDropDownSuccess(data:any){
    console.log(data);
    this.ServiceRequestDropDown=data;
  }
  
  CreateServiceRequestSuccess(input:any){
    this._router.navigate(['customer/servicerequest']);
  }
  @Input("grid-data")  
  set SetGridData(_griddata:any){    
    debugger;  
    this.isbtn=_griddata.isbtn;
    this.CreatRequest.Description=_griddata.description;
    this.CreatRequest.srId=_griddata.srId;
    this.CreatRequest.Categoty=_griddata.srcId;
    console.log("grid-data loading",this.gridData);
    
  }
  @Output("create-request")
  _createemitemitter:EventEmitter<any>=new EventEmitter<any>();
  createRequest(){
    this._createemitemitter.emit(this.CreatRequest);
  }
  @Output("update-request")
  _updateemitemitter:EventEmitter<any>=new EventEmitter<any>();
  UpdateRequest(){
    
    this._updateemitemitter.emit(this.CreatRequest);
  }
 
}
