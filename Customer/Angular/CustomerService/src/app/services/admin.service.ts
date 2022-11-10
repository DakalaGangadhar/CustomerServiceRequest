import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, throwError } from 'rxjs';
import { ApilistService } from '../apilist.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient, private _api:ApilistService,private _router:Router) { }
  AdmionLoginService(data:any){

    return this.http.post(this._api.AdmionLoginUrl,data)
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
  AdmionDataService(data:any){

    return this.http.post(this._api.AdmionDataUrl,data)
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
  ApproveService(data:any){

    return this.http.put(this._api.AdminApproveUrl+'?srId='+ data,'')
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
  RejectService(data:any){

    return this.http.put(this._api.AdminRejectUrl+'?srId='+ data,'')
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
