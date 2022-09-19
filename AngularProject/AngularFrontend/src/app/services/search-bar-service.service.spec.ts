import { TestBed } from '@angular/core/testing';

import { SearchBarServiceService } from './search-bar-service.service';

describe('SearchBarServiceService', () => {
  let service: SearchBarServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchBarServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
