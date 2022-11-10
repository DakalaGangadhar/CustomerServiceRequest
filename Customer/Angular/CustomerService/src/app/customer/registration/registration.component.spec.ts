import { DatePipe } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { RegistrationService } from 'src/app/services/registration.service';

import { RegistrationComponent } from './registration.component';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;

  beforeEach(async () => {
    let http:HttpClient;
    let router:Router;
    let registrer:RegistrationService;
    let datepipe:DatePipe;
    await TestBed.configureTestingModule({
      declarations: [ RegistrationComponent ],
      imports:[HttpClientTestingModule, HttpClientModule,RouterModule,DatePipe],
      providers: [
        DatePipe
      ],
    })
    .compileComponents();
    http=TestBed.inject(HttpClient);
    router=TestBed.inject(Router);
    registrer=TestBed.inject(RegistrationService);
    datepipe=TestBed.inject(DatePipe);
    
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should have a registration customer', async(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.registrationCustomer();
    expect(data).toEqual();
  }));
  it('should have a get country', async(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.getCountry();
    expect(data).toEqual();
  }));
  it('should have a get customer data', async(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.GetCustomerData();
    expect(data).toEqual();
  }));
  it('should have a update customer data', async(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.UpdateCustomerProfile();
    expect(data).toEqual();
  }));
});
