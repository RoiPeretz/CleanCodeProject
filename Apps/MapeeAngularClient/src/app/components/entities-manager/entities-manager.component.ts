import { Component, OnInit} from '@angular/core';
// import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { MapEntitiesService } from 'src/app/services/mapEntities/map-entities.service';
import { MissionMapService } from 'src/app/services/missionMap/mission-map.service';
// import { iMapEntity } from 'src/app/Models/mapEntityModels/iMap-entity.model';

@Component({
  selector: 'app-entities-manager',
  templateUrl: './entities-manager.component.html',
  styleUrls: ['./entities-manager.component.css']
})
export class EntitiesManagerComponent implements OnInit {
  
  // private canvas: HTMLCanvasElement = new HTMLCanvasElement();
  // private context: CanvasRenderingContext2D = new CanvasRenderingContext2D();
  // private paint: boolean = false;
  
  // private clickX: number[] = [];
  // private clickY: number[] = [];
  // private clickDrag: boolean[] = [];  
  
  constructor(private mapEntitiesService: MapEntitiesService, private missionMapService: MissionMapService) {      
    // let canvas = document.getElementById('canvas') as
    // HTMLCanvasElement;
    // let context = canvas.getContext("2d");
    // if (context == null) return;
    // context.lineCap = 'round';
    // context.lineJoin = 'round';
    // context.strokeStyle = 'black';
    // context.lineWidth = 1;

    // this.canvas = canvas;
    // this.context = context;

    // this.redraw();
    // this.createUserEvents(); 
  }

    private _map: string = "";

  ngOnInit(): void {
      let missionMapObserver = this.missionMapService.missionMapChanged;
      missionMapObserver.subscribe( (map) => {this._map = map;} )
  }

//   private createUserEvents() {
//     let canvas = this.canvas;

//     canvas.addEventListener("mouseup", this.releaseEventHandler);

//     // document.getElementById('clear')
//     //         .addEventListener("click", this.clearEventHandler);
// }

// private redraw() {
//     let clickX = this.clickX;
//     let context = this.context;
//     let clickDrag = this.clickDrag;
//     let clickY = this.clickY;
//     for (let i = 0; i < clickX.length; ++i) {
//         context.beginPath();
//         if (clickDrag[i] && i) {
//             context.moveTo(clickX[i - 1], clickY[i - 1]);
//         } else {
//             context.moveTo(clickX[i] - 1, clickY[i]);
//         }

//         context.lineTo(clickX[i], clickY[i]);
//         context.stroke();
//     }
//     context.closePath();
// }

// private releaseEventHandler = () => {
//   this.paint = false;
//   this.redraw();
// }

// createForm() {
//     this.formGroup = this.formBuilder.group({'name': [null, Validators.required],
//     'x': [null, Validators.required],
//     'y': [null, Validators.required]});
//   }

  // onSubmit() {
  //   let entity : iMapEntity = new ;  
  //   entity.name = this.formGroup.get('name')?.value;
  // }
}
