import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { RegistrationService } from './registration.service';

@Injectable({
    providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {


    constructor(private injector: Injector) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let registrationService = this.injector.get(RegistrationService);
        let tokenizedreq = req.clone({
            headers: req.headers.set('Authorization', 'bearer ' + registrationService.getToken())
        })

        return next.handle(tokenizedreq);
    }

}