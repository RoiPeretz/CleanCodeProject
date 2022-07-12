import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { IMapModel } from 'src/app/Models/mapModel/iMapModel';
import { MapDummyData } from './mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MapsService {
  private readonly _mapAdded: Subject<IMapModel> = new Subject<IMapModel>();

  public get mapAdded(): Observable<IMapModel> {
    return this._mapAdded.asObservable();
  }

  public getAllMaps(): Observable<Iterable<IMapModel>> {
    const arraySource = of(MapDummyData);
    return arraySource;
  }

  public addMap(map: IMapModel): Observable<boolean> {
    MapDummyData.push(map);
    this._mapAdded.next(map);
    const arraySource = of(true);
    return arraySource;
  }

  public deleteMap(map: IMapModel): Observable<boolean> {
    MapDummyData.splice(MapDummyData.indexOf(map), 1);
    const arraySource = of(true);
    return arraySource;
  }
}
