import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { async, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { of } from 'rxjs';
import { stream } from 'xlsx';
import { ApilistService } from '../apilist.service';

import { AdminService } from './admin.service';

describe('AdminService', () => {
  let service: AdminService;
  let http:HttpClient;
  let apilist:ApilistService;
  let router:Router;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterModule,HttpClientTestingModule],
    });
    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.inject(AdminService);
    http= TestBed.inject(HttpClient);  
    apilist=TestBed.inject(ApilistService);
    router=TestBed.inject(Router); 
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('should be admin data', () => {
    var test={
      Email:'test@simple.com',
      Status:1
    }
    let data=service.AdmionDataService(test);
    expect(service).toBeTruthy();
  });
  it("should return admin login data", () => {
    
    let result:any=[];
    let resultdata = {
      token:"diuge9vurhgrfbvfuh"
    };
    let data={
      email: "test@gmail.com",
      password: "1234"
    };
    service.AdmionLoginService(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.AdmionLoginUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return admin  data", () => {
   
    let result:any=[];
    let resultdata = [
      {
        srId: 28,
        cusromername: "Ganesha",
        country: "India",
        state: "Andhra Pradesh",
        district: "Kadapa",
        address: "kadapa",
        phonenumber: "9876543299",
        pancard: "ABCDE1234F",
        description: "Laptop always restart",
        status: "Pending",
        category: "Laptop issue",
        assignto: "Manager 3",
        date: null
      },
      {
        srId: 30,
        cusromername: "test",
        country: "India",
        state: "Andhra Pradesh",
        district: "test",
        address: "test",
        phonenumber: "9876543299",
        pancard: "AAAAA1234F",
        description: "Laptop always restart",
        status: "Pending",
        category: "Laptop issue",
        assignto: "Manager 3",
        date: null
      },
     
    ];
    let data={
      email: "test@gmail.com",
      password: "1234"
    };
    service.AdmionDataService(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.AdmionDataUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
 
  it("should call put API to Approve a admin", () => {
  
    let result:any=[];
    let resultdata =      
    {
      srId: 5,
description: "update test data",
registrationId: 3,
srcId: 3,
assignId: 3,
statusId: 3,
createrequestdate: "2022-11-06T06:50:06.0147623"
    };
    let data=8;
    service.ApproveService(data).subscribe(t => {
      result = t;
    });
   
    let req = httpTestingController.expectOne({
      method: "PUT",
      url: apilist.AdminApproveUrl+'?srId='+ data
    });
    req.flush([resultdata]);
    expect(result[0]).toEqual(resultdata);
  });
  it("should call put API to reject a admin", () => {
   
    let result:any=[];
    let resultdata =      
    {
      srId: 5,
description: "update test data",
registrationId: 3,
srcId: 3,
assignId: 3,
statusId: 3,
createrequestdate: "2022-11-06T06:50:06.0147623"
    };
    let data=8;
    service.RejectService(data).subscribe(t => {
      result = t;
    });
   
    let req = httpTestingController.expectOne({
      method: "PUT",
      url: apilist.AdminRejectUrl+'?srId='+ data
    });
    req.flush([resultdata]);
    expect(result[0]).toEqual(resultdata);
  });
});
