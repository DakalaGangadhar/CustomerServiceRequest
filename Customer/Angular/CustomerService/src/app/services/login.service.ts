import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, throwError } from 'rxjs';
import { ApilistService } from '../apilist.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient,private _router:Router, private _api:ApilistService) { }
  CustomerLogin(data:any){

    return this.http.post(this._api.CustomerLoginUrl, data)
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
  logginIn(){
    return !!localStorage.getItem('token');
  }
  logoutUser(){
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('adminemail') 
    this._router.navigate(['']);
  }
}
