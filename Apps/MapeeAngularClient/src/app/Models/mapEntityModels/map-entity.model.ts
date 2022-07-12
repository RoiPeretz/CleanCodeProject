import { IMapEntity } from "./iMap-entity.model"

export class MapEntity implements IMapEntity {
    constructor(public Title: string, public XPosition: number, public YPosition: number) { }
}
