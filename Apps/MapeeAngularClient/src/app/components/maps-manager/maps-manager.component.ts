import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectionListChange } from '@angular/material/list';
import { Observable, map, shareReplay, first } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';
import { MissionMapService } from 'src/app/services/missionMap/mission-map.service';
import { MapUploaderDialogComponent } from '../map-uploader/map-uploader-dialog.component';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit {
  public maps: IMapModel[];
  public selectedMap: IMapModel | undefined;
  public missionMap: string | undefined;

  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private readonly mapService: MapsService,
    private readonly missionMapService: MissionMapService,
    private dialogRef: MatDialog
  ) {
    this.maps = [];

    mapService.getAllMaps().subscribe((maps) => {
      this.maps = Array.from(maps);
    });

    missionMapService.missionMapChanged.subscribe((map) => {
      this.missionMap = map;
    });
  }

  ngOnInit(): void {}

  onSelectionChange(event: MatSelectionListChange): void {
    this.selectedMap = event.options[0]?.value;
  }

  onDeleteMapRequested(): void {
    if (!this.selectedMap || this.selectedMap.name === this.missionMap) return;
    let removedMap = this.selectedMap;
    let removeRequest = this.mapService.deleteMap(this.selectedMap);

    removeRequest.pipe(first()).subscribe((success) => {
      if (!success) return;
      this.maps.splice(this.maps.indexOf(removedMap), 1);
    });
  }

  onSetMissionMapRequest() {
    if (!this.selectedMap) return;
    this.missionMapService.publishAsMissionMap(this.selectedMap);
  }

  openDialog() {
    this.dialogRef.open(MapUploaderDialogComponent, {
      width: '400px',
    });
  }
}
