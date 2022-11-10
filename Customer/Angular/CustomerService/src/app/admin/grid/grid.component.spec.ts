import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminService } from 'src/app/services/admin.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { GridComponent } from './grid.component';

describe('GridComponent', () => {
  let component: GridComponent;
  let fixture: ComponentFixture<GridComponent>;

  beforeEach(async () => {
    let apilist:AdminService;
    await TestBed.configureTestingModule({
      declarations: [ GridComponent ],
      imports: [HttpClientTestingModule],
    })
    .compileComponents();
    apilist=TestBed.inject(AdminService);

    fixture = TestBed.createComponent(GridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should have a get admin data', async(() => {
    fixture = TestBed.createComponent(GridComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.GetAdminData();
    expect(data).toEqual();
  }));
  it('should have a service request approve', async(() => {
    fixture = TestBed.createComponent(GridComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.approveGrid(8);
    expect(data).toEqual();
  }));
  it('should have a service request reject', async(() => {
    fixture = TestBed.createComponent(GridComponent);
    component = fixture.debugElement.componentInstance;
    let data=component.rejectGrid(3);
    expect(data).toEqual();
  }));
});
