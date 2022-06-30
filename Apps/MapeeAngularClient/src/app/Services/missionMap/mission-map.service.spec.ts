import { TestBed } from '@angular/core/testing';
import { MissionMapService } from './mission-map.service';

describe('MissionMapService', () => {
  let service: MissionMapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MissionMapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
