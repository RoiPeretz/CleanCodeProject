import { IMapEntity } from './iMap-entity.model';

export class MapEntity implements IMapEntity {
  constructor(
    public title: string,
    public xPosition: number,
    public yPosition: number
  ) { }
}
