import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { ApilistService } from '../apilist.service';

@Injectable({
  providedIn: 'root'
})
export class CreaterequestService {

  constructor(private http:HttpClient, private _api:ApilistService) { }
  GetCreaterequestServiceDropDownList(){

    return this.http.get(this._api.CustomerServiceRequestCategoryUrl)
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
  CreateServiceRequest(data:any){

    return this.http.post(this._api.CreateServiceRequestUrl,data)
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
  UpdateServiceRequest(data:any){

    return this.http.put(this._api.UpdateServiceRequestUrl,data)
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
