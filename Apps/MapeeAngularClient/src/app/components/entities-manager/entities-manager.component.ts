import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { MissionMapService } from 'src/app/services/missionMap/mission-map.service';
import { MapEntitiesService } from 'src/app/services/mapEntities/map-entities.service';
import { MapEntity } from 'src/app/models/mapEntityModels/map-entity.model';
import { MapDummyData } from 'src/app/services/maps/mapDummyData';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapModel } from 'src/app/models/mapModel/mapModel';
@Component({
  selector: 'app-entities-manager',
  templateUrl: './entities-manager.component.html',
  styleUrls: ['./entities-manager.component.css']
})
export class EntitiesManagerComponent implements OnInit, AfterViewInit {

  public map: IMapModel;

  public entityImageSrc: string;

  public entityImageElement: ElementRef;

  private _canvas!: HTMLCanvasElement;

  @ViewChild('canvas')
  private _canvasRef: ElementRef = {} as ElementRef;

  mapEntityForm = this.formBuilder.group({
    name: new FormControl<string>('', Validators.required),
    x: [0, [Validators.required, Validators.pattern("^[0-9]*$")]],
    y: [0, [Validators.required, Validators.pattern("^[0-9]*$")]]
  });

  constructor(private formBuilder: FormBuilder, private mapEntitiesService: MapEntitiesService,
    private missionMapService: MissionMapService) {
    this.map = new MapModel("empty", "");
    this.entityImageSrc = "../../../assets/location.png"
    this.entityImageElement = new ElementRef(document.getElementById("entityImage"));
  }

  ngOnInit(): void {
    let missionMapObserver = this.missionMapService.missionMapChanged;
    missionMapObserver.subscribe((mapName) => {
      let currentMap = MapDummyData.find((map) => map.name == mapName);
      if (currentMap == undefined) {
        this.map = new MapModel("empty", "");
      } else {
        this.map = currentMap;
      }
    })
  }

  ngAfterViewInit(): void {
    this.entityImageElement.nativeElement = document.getElementById("mapEntity");
    this.subscribeToFormChanges();
  }

  onSubmit() {
    let name = this.mapEntityForm.value.name as string;
    let x = this.mapEntityForm.value.x as number;
    let y = this.mapEntityForm.value.y as number;
    let entity = new MapEntity(name, x, y)
    this.mapEntitiesService.addMapEntity(entity).subscribe();
    this.mapEntityForm.reset();
  }

  private subscribeToFormChanges() {
    this.mapEntityForm.valueChanges.subscribe((values) => {
      if (values.x == null || values.y == null) return;

      this.moveIcon(values.x, values.y);
    })
  }

  public onClick(e: MouseEvent) {
    this.mapEntityForm.controls.x.setValue(e.offsetX);
    this.mapEntityForm.controls.y.setValue(e.offsetY);

    this.moveIcon(e.offsetX, e.offsetY);
  }

  private moveIcon(newX: number, newY: number) {
    this.entityImageElement.nativeElement.style.transform = `translate(${newX}px, ${newY}px)`
  }
}
