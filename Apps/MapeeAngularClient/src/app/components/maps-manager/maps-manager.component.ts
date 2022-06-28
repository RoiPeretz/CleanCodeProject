import { Component, OnInit } from '@angular/core';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from '../../Services/maps/maps.service';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit {
  public Maps: IMapModel[];

  constructor(private readonly MapService: MapsService) {
    var current = MapService.GetAllMaps();
    this.Maps = Array.from(current);
  }

  ngOnInit(): void {}

  mapSelectionChanged(map: IMapModel) {
    console.log(map);
  }
}
