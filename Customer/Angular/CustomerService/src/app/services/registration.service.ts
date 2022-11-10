import { Injectable } from '@angular/core';
import { ApilistService } from '../apilist.service';
import { HttpClient } from '@angular/common/http';
import { catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http:HttpClient, private _api:ApilistService) { }
  getToken(){
    return localStorage.getItem('token');
  }

  GetCountryList(){

    return this.http.get(this._api.CustomerCountryUrl)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
  GetStateList(coutryId:any){

    return this.http.get(this._api.CustomerStateUrl+'?countryid='+coutryId)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
  GetDistrictList(stateId:any){

    return this.http.get(this._api.CustomerDistrictUrl+'?stateid='+stateId)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
  CustomerRegistration(data:any){

    return this.http.post(this._api.CustomerRegistrationUrl, data)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
  GetCustomerData(data:any){

    return this.http.post(this._api.GetCustomerData, data)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
  UpdateCustomerProfile(data:any){

    return this.http.put(this._api.CustomerUpdateUrl, data)
      .pipe(map((data: any) => {     
        return data;
      })
      ,
       catchError((error) => {    // handle error
         
          if (error.status == 404) {
            //Handle Response code here
          }
          return throwError(error);
        })
      );
  }
}
