import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CRUDTypeComponent } from './crudtype.component';

describe('CRUDTypeComponent', () => {
  let component: CRUDTypeComponent;
  let fixture: ComponentFixture<CRUDTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CRUDTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CRUDTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
