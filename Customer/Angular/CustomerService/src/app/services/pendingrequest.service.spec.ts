import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { ApilistService } from '../apilist.service';

import { PendingrequestService } from './pendingrequest.service';

describe('PendingrequestService', () => {
  let service: PendingrequestService;
  let http:HttpClient;
  let router:Router;
  let apilist:ApilistService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule,RouterModule,HttpClientTestingModule]
    });
    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.inject(PendingrequestService);
    http= TestBed.inject(HttpClient);
    apilist=TestBed.inject(ApilistService);
    router=TestBed.inject(Router);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it("should get customer pending and reject data", () => {
    
    let result:any=[];
    let resultdata =[
      {
        srId: 1,
        cusromername: "test",
        country: "india",
        state: "ka",
        district: "Bangalore",
        address: "bangalore",
        phonenumber: "123456",
        pancard: "AAAAA4321Q",
        description: "testing issue",
        status: "Pending",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 4",
        date: "08-11-2022"
      },
      {
        srId: 10,
        cusromername: "test1",
        country: "uk",
        state: "ka",
        district: "uk",
        address: "uk",
        phonenumber: "87655242352",
        pancard: "BBBBB4321Q",
        description: "testing issue data",
        status: "reject",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 3",
        date: "08-10-2022"
      }
    ]
    let data={      
        email: "test@gmail.com",
        status: 0      
    };
    service.GetPendingServiceRequestData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.GetpendingrejectservicerequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should get customer approved data", () => {
    
    let result:any=[];
    let resultdata =[
      {
        srId: 1,
        cusromername: "test",
        country: "india",
        state: "ka",
        district: "Bangalore",
        address: "bangalore",
        phonenumber: "123456",
        pancard: "AAAAA4321Q",
        description: "testing issue",
        status: "Pending",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 4",
        date: "08-11-2022"
      },
      {
        srId: 10,
        cusromername: "test1",
        country: "uk",
        state: "ka",
        district: "uk",
        address: "uk",
        phonenumber: "87655242352",
        pancard: "BBBBB4321Q",
        description: "testing issue data",
        status: "reject",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 3",
        date: "08-10-2022"
      }
    ]
    let data={      
        email: "test@gmail.com",
        status: 3    
    };
    service.GetCloseServiceRequestData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.GetPendingServiceRequest
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should get customer closed  data", () => {
    
    let result:any=[];
    let resultdata =[
      {
        srId: 1,
        cusromername: "test",
        country: "india",
        state: "ka",
        district: "Bangalore",
        address: "bangalore",
        phonenumber: "123456",
        pancard: "AAAAA4321Q",
        description: "testing issue",
        status: "Pending",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 4",
        date: "08-11-2022"
      }
    ]
    let data={      
        email: "test@gmail.com",
        status: 3    
    };
    service.SearchServiceRequestData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.SearchServiceRequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should get customer search data", () => {
    
    let result:any=[];
    let resultdata =[
      {
        srId: 1,
        cusromername: "test",
        country: "india",
        state: "ka",
        district: "Bangalore",
        address: "bangalore",
        phonenumber: "123456",
        pancard: "AAAAA4321Q",
        description: "testing issue",
        status: "Pending",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 4",
        date: "08-11-2022"
      },
      {
        srId: 10,
        cusromername: "test1",
        country: "uk",
        state: "ka",
        district: "uk",
        address: "uk",
        phonenumber: "87655242352",
        pancard: "BBBBB4321Q",
        description: "testing issue data",
        status: "reject",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 3",
        date: "08-10-2022"
      }
    ]
    let data={      
        email: "test@gmail.com",
        status: 3    
    };
    service.SearchServiceRequestData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.SearchServiceRequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should get customer all data", () => {
    
    let result:any=[];
    let resultdata =[
      {
        srId: 1,
        cusromername: "test",
        country: "india",
        state: "ka",
        district: "Bangalore",
        address: "bangalore",
        phonenumber: "123456",
        pancard: "AAAAA4321Q",
        description: "testing issue",
        status: "Pending",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 4",
        date: "08-11-2022"
      },
      {
        srId: 10,
        cusromername: "test1",
        country: "uk",
        state: "ka",
        district: "uk",
        address: "uk",
        phonenumber: "87655242352",
        pancard: "BBBBB4321Q",
        description: "testing issue data",
        status: "reject",
        category: "Laptop turns on and off repeatedly",
        assignto: "Manager 3",
        date: "08-10-2022"
      }
    ]
    let data={      
        email: "test@gmail.com",
        status: 0
    };
    service.GetAllServiceRequestData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.GetAllServiceRequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should reopen request service", () => {
  
    let result:any=[];
    let resultdata =      
    {
      srId: 5,
      description: "update test data",
      registrationId: 3,
      srcId: 3,
      assignId: 3,
      statusId: 1,
      createrequestdate: "2022-11-06T06:50:06.0147623"
    };
    let data=8;
    service.closegridReopenData(data).subscribe(t => {
      result = t;
    });
   
    let req = httpTestingController.expectOne({
      method: "PUT",
      url: apilist.ReopenUrl+'?srId='+ data
    });
    req.flush([resultdata]);
    expect(result[0]).toEqual(resultdata);
  });
  it("should delete request service", () => {
  
    let result:any=[];
    let resultdata =      
    {
      srId: 5,
      description: "update test data",
      registrationId: 3,
      srcId: 3,
      assignId: 3,
      statusId: 1,
      createrequestdate: "2022-11-06T06:50:06.0147623"
    };
    let data=8;
    service.closegridDelete(data).subscribe(t => {
      result = t;
    });
   
    let req = httpTestingController.expectOne({
      method: "Delete",
      url: apilist.DeleteServiceRequestUrl+'?srId='+ data
    });
    req.flush([resultdata]);
    expect(result[0]).toEqual(resultdata);
  });
  it("should get request service data by srid", () => {
  
    let result:any=[];
    let resultdata =      
    {
      srcId: 1,
      srId: 4,
      description: "Hi Close",
      category: "Your computer does not turn on"
    };
    let data=8;
    service.GetServiceRequestData(data).subscribe(t => {
      result = t;
    });
   
    let req = httpTestingController.expectOne({
      method: "Get",
      url: apilist.GetServiceRequestDataUrl+'?srId='+ data
    });
    req.flush([resultdata]);
    expect(result[0]).toEqual(resultdata);
  });
});
