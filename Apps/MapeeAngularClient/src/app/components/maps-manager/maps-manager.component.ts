import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectionListChange } from '@angular/material/list';
import { Observable, map, shareReplay, first, Subscription } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';
import { MissionMapService } from 'src/app/services/missionMap/mission-map.service';
import { MapUploaderDialogComponent } from '../map-uploader/map-uploader-dialog.component';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit, OnDestroy {
  //#region Members
  public maps: IMapModel[];
  public selectedMap: IMapModel | undefined;
  public missionMap: string | undefined;
  public isHandset: Observable<boolean> | undefined;
  private subscriptions: Subscription[] = [];
  //#endregion

  constructor(
    private readonly _breakpointObserver: BreakpointObserver,
    private readonly _mapService: MapsService,
    private readonly _missionMapService: MissionMapService,
    private _dialogRef: MatDialog
  ) {
    this.maps = [];
    this.getAllExistingMaps();
    this.subscribeForDeviceChanges();
    this.subscribeForMapAdded();
    this.subscribeForMissionMapChange(_missionMapService);
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }

  onSelectionChanged(event: MatSelectionListChange): void {
    this.selectedMap = event.options[0]?.value;
  }

  onDeleteMapRequested(): void {
    if (!this.selectedMap || this.selectedMap.name === this.missionMap) return;
    let removedMap = this.selectedMap;
    let removeRequest = this._mapService.deleteMap(this.selectedMap);

    removeRequest.pipe(first()).subscribe((success) => {
      if (!success) return;
      this.maps.splice(this.maps.indexOf(removedMap), 1);
      this.selectedMap = undefined;
    });
  }

  onSetMissionMapRequest() {
    if (!this.selectedMap) return;
    this._missionMapService.publishAsMissionMap(this.selectedMap);
  }

  openDialog() {
    this._dialogRef.open(MapUploaderDialogComponent, {
      width: '405px',
    });
  }

  //#region Private methods
  private onMissionmapChanged(map: string) {
    this.missionMap = map;
  }

  private getAllExistingMaps() {
    this._mapService
      .getAllMaps()
      .pipe(first())
      .subscribe((maps) => {
        this.maps = Array.from(maps);
      });
  }

  private subscribeForDeviceChanges() {
    this.isHandset = this._breakpointObserver.observe(Breakpoints.Handset).pipe(
      map((result) => result.matches),
      shareReplay()
    );
  }

  private subscribeForMissionMapChange(_missionMapService: MissionMapService) {
    const missionMapObservable = _missionMapService.missionMapChanged;
    if(!missionMapObservable) return;
    
    this.subscriptions.push(
      missionMapObservable.subscribe(
        this.onMissionmapChanged.bind(this)
      )
    );
  }

  private subscribeForMapAdded() {
    this.subscriptions.push(
      this._mapService.mapAdded.subscribe((map) => {
        this.maps.push(map);
      })
    );
  }
  //#endregion
}
