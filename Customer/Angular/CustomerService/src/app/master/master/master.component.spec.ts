import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginService } from 'src/app/services/login.service';

import { MasterComponent } from './master.component';

describe('MasterComponent', () => {
  let component: MasterComponent;
  let fixture: ComponentFixture<MasterComponent>;

  beforeEach(async () => {
    let loginService:LoginService;
    await TestBed.configureTestingModule({
      declarations: [ MasterComponent ],
      imports:[HttpClientTestingModule]
    })
    .compileComponents();
    loginService=TestBed.inject(LoginService);

    fixture = TestBed.createComponent(MasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
