import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectionListChange } from '@angular/material/list';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';
import { MapUploaderDialogComponent } from '../map-uploader/map-uploader-dialog.component';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit {
  public Maps: IMapModel[];
  public SelectedMap: IMapModel | undefined;

  constructor(private readonly MapService: MapsService, private dialogRef: MatDialog) {
    this.Maps = [];
    MapService.GetAllMaps().subscribe((maps) => {
      this.Maps = Array.from(maps);
    });
  }

  ngOnInit(): void { }

  onSelectionChange(event: MatSelectionListChange): void {
    this.SelectedMap = event.options[0]?.value;
  }

  openDialog() {
    this.dialogRef.open(MapUploaderDialogComponent, {
      width: '400px',
    });
  }
}
