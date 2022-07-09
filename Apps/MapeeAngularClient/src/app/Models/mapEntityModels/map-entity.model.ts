import { IMapEntity } from "./iMap-entity.model"

export class MapEntity implements IMapEntity {
    constructor(public name: string, public x: number, public y: number) {}
}
