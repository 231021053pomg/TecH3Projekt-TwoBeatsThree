import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadOrdersComponent } from './read-orders.component';

describe('ReadOrdersComponent', () => {
  let component: ReadOrdersComponent;
  let fixture: ComponentFixture<ReadOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReadOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
