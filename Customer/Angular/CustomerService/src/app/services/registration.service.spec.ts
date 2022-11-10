import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ApilistService } from '../apilist.service';

import { RegistrationService } from './registration.service';

describe('RegistrationService', () => {
  let service: RegistrationService;
  let http:HttpClient;
  let apilist:ApilistService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule,HttpClientTestingModule]
    });
    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.inject(RegistrationService);
    http= TestBed.inject(HttpClient);
    apilist=TestBed.inject(ApilistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it("should return get country data", () => {
    
    let result:any=[];
    let resultdata = [
      {
        cId: 1,
        countryname: "India"
      },
      {
        cId: 4,
        countryname: "uk"
      }
    ]
    
    service.GetCountryList().subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Get",
      url: apilist.CustomerCountryUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return get state data", () => {
    debugger;
    let result:any=[];
    let resultdata = [
      {
        stateId: 1,
        statename: "Andhra Pradesh",
        cId: 1
      },
      {
        stateId: 2,
        statename: "KA",
        cId: 1
      }
    ]
    let countryid=1;
    service.GetStateList(countryid).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Get",
      url: apilist.CustomerStateUrl+'?countryid='+countryid
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return get district data", () => {
   
    let result:any=[];
    let resultdata = [
      {
        districtId: 1,
        districtname: "Kadapa",
        stateId: 1
      },
      {
        districtId: 2,
        districtname: "Karnool",
        stateId: 1
      }
    ]
    let stateid=1;
    service.GetDistrictList(stateid).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Get",
      url: apilist.CustomerDistrictUrl+'?stateid='+stateid
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return customer registration data", () => {
   
    let result:any=[];
    let resultdata = {
      registrationId: 17,
      customerAddress: "test address",
      customerCountry: "1",
      customerPhoneNumber: "12345678",
      customerPassword: "1234",
      customerPanCard: "ASDFG1234E",
      customerName: "test",
      customerEmail: "test@gmail.com",
      customerDistrict: "2",
      customerDOB: "20-01-1999",
      customerState: "1"
    }
    let data= {
        registrationId: 17,
        customerAddress: "test address",
        customerCountry: "1",
        customerPhoneNumber: "12345678",
        customerPassword: "1234",
        customerPanCard: "ASDFG1234E",
        customerName: "test",
        customerEmail: "test@gmail.com",
        customerDistrict: "2",
        customerDOB: "20-01-1999",
        customerState: "1"
      };
    
    service.CustomerRegistration(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.CustomerRegistrationUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return get customer registration data", () => {
   
    let result:any=[];
    let resultdata = {
      registrationId: 3,
      email: "test@gmail.com",
      password: "1234",
      customername: "test",
      address: "prod",
      pancard: "AAAAA1234G",
      contactnumber: "12345678",
      dob: "2022-07-08T00:00:00",
      cId: 1,
      stateId: 2,
      districtId: 6,
      registrationDate: "2022-11-09T03:33:04.274365"
    }
    let data= {
      email: "test@gmail.com",
      status: 0
      };
    
    service.GetCustomerData(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.GetCustomerData
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  it("should return customer update data", () => {
   
    let result:any=[];
    let resultdata = {
      registrationId: 3,
      email: "test@gmail.com",
      password: "1234",
      customername: "test",
      address: "prod",
      pancard: "AAAAA1234G",
      contactnumber: "12345678",
      dob: "2022-07-08T00:00:00",
      cId: 1,
      stateId: 2,
      districtId: 6,
      registrationDate: "2022-11-09T03:33:04.274365"
    }
    let data= {
        registrationId: 17,
        customerAddress: "test address",
        customerCountry: "1",
        customerPhoneNumber: "12345678",
        customerPassword: "1234",
        customerPanCard: "ASDFG1234E",
        customerName: "test",
        customerEmail: "test@gmail.com",
        customerDistrict: "2",
        customerDOB: "20-01-1999",
        customerState: "1"
      };
    
    service.UpdateCustomerProfile(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Put",
      url: apilist.CustomerUpdateUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
});
