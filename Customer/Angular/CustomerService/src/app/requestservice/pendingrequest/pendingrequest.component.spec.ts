import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CreaterequestService } from 'src/app/services/createrequest.service';
import { ExcelService } from 'src/app/services/excel.service';
import { PendingrequestService } from 'src/app/services/pendingrequest.service';

import { PendingrequestComponent } from './pendingrequest.component';

describe('PendingrequestComponent', () => {
  let component: PendingrequestComponent;
  let fixture: ComponentFixture<PendingrequestComponent>;

  beforeEach(async () => {
    let http:HttpClient;
    let router:Router;
    let pendingrequestService:PendingrequestService;
    let createrequestService:CreaterequestService;
    let excelService:ExcelService;
    await TestBed.configureTestingModule({
      declarations: [ PendingrequestComponent ],
      imports:[HttpClientTestingModule, HttpClientModule,RouterModule,FormsModule]
    })
    .compileComponents();
    http=TestBed.inject(HttpClient);
    router=TestBed.inject(Router);
    pendingrequestService=TestBed.inject(PendingrequestService);
    createrequestService=TestBed.inject(CreaterequestService);
    excelService=TestBed.inject(ExcelService);

    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should have a get pending service request', async(() => {
    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.GetPendingServiceRequest();
    expect(data).toEqual();
  }));
  it('should have a get close service request', async(() => {
    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.GetCloseServiceRequest();
    expect(data).toEqual();
  }));
  it('should have a get close reopen', async(() => {
    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.closegridReopen(1);
    expect(data).toEqual();
  }));
  it('should have a get close delete', async(() => {
    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.closegridDelete(2);
    expect(data).toEqual();
  }));
  it('should have a get excel', async(() => {
    fixture = TestBed.createComponent(PendingrequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.exportAsXLSX();
    expect(data).toEqual();
  }));
});
