import { TestBed } from '@angular/core/testing';

import { DoorstatusService } from './doorstatus.service';

describe('DoorstatusService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DoorstatusService = TestBed.get(DoorstatusService);
    expect(service).toBeTruthy();
  });
});
