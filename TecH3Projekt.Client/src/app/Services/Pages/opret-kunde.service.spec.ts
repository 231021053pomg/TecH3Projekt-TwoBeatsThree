import { TestBed } from '@angular/core/testing';

import { OpretKundeService } from './opret-kunde.service';

describe('OpretKundeService', () => {
  let service: OpretKundeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpretKundeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
