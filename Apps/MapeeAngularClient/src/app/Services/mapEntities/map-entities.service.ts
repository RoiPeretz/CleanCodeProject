import { Injectable } from '@angular/core';
import { iMapEntity } from 'src/app/models/mapEntityModels/iMap-entity.model';

@Injectable({
  providedIn: 'root'
})
export class MapEntitiesService {

  constructor() { }

  addMapEntity(entity : iMapEntity) {
    console.log("added entity ", entity.name)
  }
}
