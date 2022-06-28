import { IMapModel } from './iMapModel';

export class MapModel implements IMapModel {
  constructor(public name: string, public content: string) {}
}
