import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApilistService {

  constructor() { }
  public baseUrl:string='http://localhost:14402';
  public CustomerRegistrationUrl:string=this.baseUrl + '/api/gateway/registration/customer-registration';
  public CustomerLoginUrl:string=this.baseUrl + '/api/gateway/registration/customer-login';
  public CustomerCountryUrl:string=this.baseUrl + '/api/gateway/registration/customer-country';
  public CustomerStateUrl:string=this.baseUrl + '/api/gateway/registration/customer-state';
  public CustomerDistrictUrl:string=this.baseUrl + '/api/gateway/registration/customer-district';
  public GetCustomerData:string=this.baseUrl + '/api/gateway/registration/customer-getcustomerdata';
  public CustomerUpdateUrl:string=this.baseUrl + '/api/gateway/registration/customer-update';

  public CustomerServiceRequestCategoryUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-servicerequestcategory';
  public CreateServiceRequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-createservicerequest';
  public GetPendingServiceRequest:string=this.baseUrl + '/api/gateway/servicerequest/customer-getpendingservicerequest';
  public SearchServiceRequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-closesearch';
  public ReopenUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-reopen';
  public DeleteServiceRequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-servicerequestdelete';
  public GetServiceRequestDataUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-getservicerequestdata';
  public UpdateServiceRequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-updateservicerequest';
  public GetAllServiceRequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-getallservicerequest';
  public GetpendingrejectservicerequestUrl:string=this.baseUrl + '/api/gateway/servicerequest/customer-getpendingrejectservicerequest';

  public AdmionLoginUrl:string=this.baseUrl + '/api/gateway/admin/admin-login';
  public AdmionDataUrl:string=this.baseUrl + '/api/gateway/admin/admin-data';
  public AdminApproveUrl:string=this.baseUrl + '/api/gateway/admin/admin-approve';
  public AdminRejectUrl:string=this.baseUrl + '/api/gateway/admin/admin-reject';

}
