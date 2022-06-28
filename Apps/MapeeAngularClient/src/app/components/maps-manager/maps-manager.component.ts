import { Component, OnInit } from '@angular/core';
import { MatSelectionListChange } from '@angular/material/list';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit {
  public Maps: IMapModel[];
  public SelectedMap: IMapModel | undefined;

  constructor(private readonly MapService: MapsService) {
    var current = MapService.GetAllMaps();
    this.Maps = Array.from(current);
  }

  ngOnInit(): void {}

  onSelectionChange(event: MatSelectionListChange): void {
    this.SelectedMap = event.options[0]?.value;
  }
}
