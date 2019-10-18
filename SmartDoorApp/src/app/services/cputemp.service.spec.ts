import { TestBed } from '@angular/core/testing';

import { CputempService } from './cputemp.service';

describe('CputempService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CputempService = TestBed.get(CputempService);
    expect(service).toBeTruthy();
  });
});
