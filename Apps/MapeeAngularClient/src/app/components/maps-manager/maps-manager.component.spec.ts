import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MapsManagerComponent } from './maps-manager.component';

describe('MapsManagerComponent', () => {
  let component: MapsManagerComponent;
  let fixture: ComponentFixture<MapsManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MapsManagerComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MapsManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
