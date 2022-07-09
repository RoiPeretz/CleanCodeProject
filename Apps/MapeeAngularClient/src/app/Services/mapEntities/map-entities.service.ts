import { Injectable } from '@angular/core';
import { IMapEntity } from 'src/app/models/mapEntityModels/iMap-entity.model';

@Injectable({
  providedIn: 'root'
})
export class MapEntitiesService {

  constructor() { }

  addMapEntity(entity : IMapEntity) {
    console.log("added entity ", entity.name)
  }
}
