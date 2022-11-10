import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { CreaterequestService } from 'src/app/services/createrequest.service';

import { CreaterequestComponent } from './createrequest.component';

describe('CreaterequestComponent', () => {
  let component: CreaterequestComponent;
  let fixture: ComponentFixture<CreaterequestComponent>;

  beforeEach(async () => {
    let router:Router;
    let createService:CreaterequestService;
    await TestBed.configureTestingModule({
      declarations: [ CreaterequestComponent ],
      imports:[HttpClientTestingModule, RouterModule]
    })
    .compileComponents();
    router=TestBed.inject(Router);
    createService=TestBed.inject(CreaterequestService);

    fixture = TestBed.createComponent(CreaterequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should have a service request category', async(() => {
    fixture = TestBed.createComponent(CreaterequestComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.GetServiceRequestCategoryDropDownData();
    expect(data).toEqual();
  }));
});
