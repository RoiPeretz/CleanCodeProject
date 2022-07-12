import { Injectable } from '@angular/core';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { IMapModel } from 'src/app/Models/mapModel/iMapModel';
import { MapDummyData } from '../maps/mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MissionMapService {
  public get missionMapChanged(): Observable<string> {
    return this._missionMap.asObservable();
  }

  private _missionMap: BehaviorSubject<string>;

  constructor() {
    this._missionMap = new BehaviorSubject<string>(MapDummyData[0].name);
  }

  publishAsMissionMap(map: IMapModel): Observable<boolean> {
    this._missionMap.next(map.name);
    const response = of(true);
    return response;
  }
}
