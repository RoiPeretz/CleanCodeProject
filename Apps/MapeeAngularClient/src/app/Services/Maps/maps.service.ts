import { Injectable } from '@angular/core';
import { IMapModel } from 'src/app/models/MapModel/iMapModel';
import { MapDummyData } from './mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MapsService {
  public GetAllMaps(): Iterable<IMapModel> {
    return MapDummyData;
  }

  public AddMap(map: IMapModel) {
    MapDummyData.push(map);
  }

  public DeleteMap(map: IMapModel) {
    MapDummyData.splice(MapDummyData.indexOf(map), 1);
  }
}
