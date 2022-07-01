import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';

@Component({
  selector: 'app-map-uploader',
  templateUrl: './map-uploader-dialog.component.html',
  styleUrls: ['./map-uploader-dialog.component.css']
})
export class MapUploaderDialogComponent {
  public Map2Upload: IMapModel = {
    name: '',
    content: ''
  };

  constructor(private mapsService: MapsService,
    public dialogRef: MatDialogRef<MapUploaderDialogComponent>) { }

  public onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (!file) return;
    this.Map2Upload.name = file.name;

    this.toBase64(file);
  }
  
  private toBase64(file: File): void {
    let reader = new FileReader();
    reader.onload = (e) => {
      const resut = e?.target?.result;
      if(!resut) return;

      this.Map2Upload.content = resut.toString();
    };
    reader.readAsDataURL(file);
  }

  public fileUpload() {
    if (!this.validateMap(this.Map2Upload)) return;

    this.mapsService.AddMap(this.Map2Upload);

    this.dialogRef.close();
  }

  public selectionChamged(event: any) {
    this.Map2Upload.name = event.target.value;
  }

  private validateMap(map: IMapModel): boolean {
    return map.name !== '' && map.content !== '';
  }
}
