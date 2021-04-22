import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OsRegistrationComponent } from './os-registration.component';

describe('OsRegistrationComponent', () => {
  let component: OsRegistrationComponent;
  let fixture: ComponentFixture<OsRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OsRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OsRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
