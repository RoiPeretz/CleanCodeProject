import { Injectable } from '@angular/core';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapDummyData } from '../maps/mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MissionMapService {
  public get missionMapChanged(): Observable<string> | undefined {
    if(!this._missionMap) return undefined;

    return this._missionMap.asObservable();
  }

  private _missionMap: BehaviorSubject<string> | undefined;

  constructor() {
    if(MapDummyData.length > 0){
      this._missionMap = new BehaviorSubject<string>(MapDummyData[0].name);
    }
  }

  publishAsMissionMap(map: IMapModel): Observable<boolean> | undefined {
    if(!this._missionMap) return undefined;

    this._missionMap.next(map.name);
    const response = of(true);
    return response;
  }
}
