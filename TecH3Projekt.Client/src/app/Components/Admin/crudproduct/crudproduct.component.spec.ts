import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CRUDProductComponent } from './crudproduct.component';

describe('CRUDProductComponent', () => {
  let component: CRUDProductComponent;
  let fixture: ComponentFixture<CRUDProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CRUDProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CRUDProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
