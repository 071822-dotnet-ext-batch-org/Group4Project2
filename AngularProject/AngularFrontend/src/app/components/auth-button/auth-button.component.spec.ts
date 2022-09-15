import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthbuttonComponent } from './auth-button.component';

describe('AuthbuttonComponent', () => {
  let component: AuthbuttonComponent;
  let fixture: ComponentFixture<AuthbuttonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthbuttonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthbuttonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
