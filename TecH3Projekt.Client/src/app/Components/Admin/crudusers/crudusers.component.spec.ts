import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CRUDUsersComponent } from './crudusers.component';

describe('CRUDUsersComponent', () => {
  let component: CRUDUsersComponent;
  let fixture: ComponentFixture<CRUDUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CRUDUsersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CRUDUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
