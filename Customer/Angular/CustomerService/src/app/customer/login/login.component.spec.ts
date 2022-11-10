import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { LoginService } from 'src/app/services/login.service';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    let router:Router;
    let _loginService:LoginService;
    let _adminService:AdminService;
    await TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      imports:[HttpClientTestingModule, RouterModule],
    })
    .compileComponents();
    router=TestBed.inject(Router);
    _loginService=TestBed.inject(LoginService);
    _adminService=TestBed.inject(AdminService);

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should have a login', async(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.debugElement.componentInstance;
    var dataLogin={
      email: "test@gmail.com",
      password:"1234"
    }
    let data=component.onClickLoginSubmit(dataLogin);
    expect(data).toEqual();
  }));
});
