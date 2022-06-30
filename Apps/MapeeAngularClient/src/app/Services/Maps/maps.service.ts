import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapDummyData } from './mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MapsService {
  public GetAllMaps(): Observable<Iterable<IMapModel>> {
    const arraySource = of(MapDummyData);
    return arraySource;
  }

  public AddMap(map: IMapModel): Observable<boolean> {
    MapDummyData.push(map);
    const arraySource = of(true);
    return arraySource;
  }

  public DeleteMap(map: IMapModel): Observable<boolean> {
    MapDummyData.splice(MapDummyData.indexOf(map), 1);
    const arraySource = of(true);
    return arraySource;
  }
}
