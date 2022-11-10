import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, throwError } from 'rxjs';
import { ApilistService } from '../apilist.service';

@Injectable({
  providedIn: 'root'
})
export class PendingrequestService {

  constructor(private http:HttpClient,private _router:Router, private _api:ApilistService) { }
  GetPendingServiceRequestData(data:any){

    return this.http.post(this._api.GetpendingrejectservicerequestUrl, data)
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
  GetCloseServiceRequestData(data:any){

    return this.http.post(this._api.GetPendingServiceRequest, data)
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
  SearchServiceRequestData(data:any){

    return this.http.post(this._api.SearchServiceRequestUrl, data)
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
  closegridReopenData(data:any){

    return this.http.put(this._api.ReopenUrl+'?srId='+ data,'')
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
  closegridDelete(data:any){

    return this.http.delete(this._api.DeleteServiceRequestUrl+'?srId='+ data)
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
  GetServiceRequestData(data:any){

    return this.http.get(this._api.GetServiceRequestDataUrl+'?srId='+ data)
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
  GetAllServiceRequestData(data:any){

    return this.http.post(this._api.GetAllServiceRequestUrl, data)
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
