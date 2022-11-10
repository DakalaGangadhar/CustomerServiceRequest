import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { ApilistService } from '../apilist.service';

import { LoginService } from './login.service';

describe('LoginService', () => {
  let service: LoginService;
  let http:HttpClient;
  let router:Router;
  let apilist:ApilistService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule,RouterModule,HttpClientTestingModule]
    });
    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.inject(LoginService);
    http= TestBed.inject(HttpClient);
    apilist=TestBed.inject(ApilistService);
    router=TestBed.inject(Router);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it("should return customer login data", () => {
   
    let result:any=[];
    let resultdata = {
      token:"diuge9vurhgrfbvfuh"
    };
    let data={
      email: "test@gmail.com",
      password: "1234"
    };
    service.CustomerLogin(data).subscribe(t => {
      result = t;
    });
    const req = httpTestingController.expectOne({
      method: "Post",
      url: apilist.CustomerLoginUrl
    });
   
    req.flush([resultdata]);
   
    expect(result[0]).toEqual(resultdata);
  });
  
});
