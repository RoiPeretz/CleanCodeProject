import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MapUploaderDialogComponent } from './map-uploader-dialog.component';

describe('MapUploaderDialogComponent', () => {
  let component: MapUploaderDialogComponent;
  let fixture: ComponentFixture<MapUploaderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MapUploaderDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MapUploaderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
