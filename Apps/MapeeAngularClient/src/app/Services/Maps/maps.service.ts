import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapDummyData } from './mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MapsService {
  public getAllMaps(): Observable<Iterable<IMapModel>> {
    const arraySource = of(MapDummyData);
    return arraySource;
  }

  public addMap(map: IMapModel): Observable<boolean> {
    MapDummyData.push(map);
    const arraySource = of(true);
    return arraySource;
  }

  public deleteMap(map: IMapModel): Observable<boolean> {
    MapDummyData.splice(MapDummyData.indexOf(map), 1);
    const arraySource = of(true);
    return arraySource;
  }
}
