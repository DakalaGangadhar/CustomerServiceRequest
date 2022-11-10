import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ApilistService } from '../apilist.service';

import { CreaterequestService } from './createrequest.service';

describe('CreaterequestService', () => {
  let service: CreaterequestService;
  let http:HttpClient;
  let apilist:ApilistService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule,HttpClientTestingModule]
    });
    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.inject(CreaterequestService);
    http= TestBed.inject(HttpClient);
    apilist=TestBed.inject(ApilistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it("should return create request data", () => {
    
    let result:any=[];
    let resultdata = {
      srId: 38,
      description: "Laptop issue",
      registrationId: 3,
      srcId: 3,
      assignId: 3,
      statusId: 1,
      createrequestdate: "2022-11-09T03:18:30.1483341Z"
    };
    let data={
      categoty: "3",
      description: "test data",
      email: "test@gmail.com"
    };
    service.CreateServiceRequest(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.CreateServiceRequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return create request data", () => {
    
    let result:any=[];
    let resultdata = [
      {
        cId: 1,
        countryname: "India"
      },
      {
        cId: 2,
        countryname: "uk"
      }
    ]
    
    service.GetCreaterequestServiceDropDownList().subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Get",
      url: apilist.CustomerServiceRequestCategoryUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return update request data", () => {
    
    let result:any=[];
    let data={
      registrationId: 0,
      customerAddress: "address",
      customerCountry: "1",
      customerPhoneNumber: "12345667",
      customerPassword: "1234",
      customerPanCard: "ASDFG1234R",
      customerName: "test",
      customerEmail: "test@gmail.com",
      customerDistrict: "3",
      customerDOB: "20-03-1999",
      customerState: "2"
    };
    let resultdata = {
      CustomerAddress:"Produr",
CustomerCountry:"1",
CustomerDOB:"2022-07-08",
CustomerDistrict:"6",
CustomerEmail:"test@gmail.com",
CustomerName:"test",
CustomerPanCard:"AAAAA1234G",
CustomerPassword:"1234",
CustomerPhoneNumber:"1234556",
CustomerState:"2",
registrationId:11
    }
    
    service.UpdateServiceRequest(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Put",
      url: apilist.UpdateServiceRequestUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
});
