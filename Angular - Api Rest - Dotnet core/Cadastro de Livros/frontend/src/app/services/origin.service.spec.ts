import { TestBed } from '@angular/core/testing';

import { BookvalueService } from './origin.service';

describe('BookvalueService', () => {
  let service: BookvalueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookvalueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
