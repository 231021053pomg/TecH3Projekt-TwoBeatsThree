import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpretKundeComponent } from './opret-kunde.component';

describe('OpretKundeComponent', () => {
  let component: OpretKundeComponent;
  let fixture: ComponentFixture<OpretKundeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpretKundeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpretKundeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
