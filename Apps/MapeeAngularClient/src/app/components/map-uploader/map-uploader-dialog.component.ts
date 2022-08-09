import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidatorFn } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapsService } from 'src/app/services/maps/maps.service';

@Component({
  selector: 'app-map-uploader',
  templateUrl: './map-uploader-dialog.component.html',
  styleUrls: ['./map-uploader-dialog.component.css']
})
export class MapUploaderDialogComponent {
  public userForm: any | undefined;
  public uploading: boolean = false;
  public errorMessages: string[] | undefined;

  public Map2Upload: IMapModel = {
    name: '',
    content: undefined
  };

  constructor(private mapsService: MapsService,
    private dialogRef: MatDialogRef<MapUploaderDialogComponent>,
    private formBulder: FormBuilder) { 
      this.errorMessages = [];
    }

  public onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (!file) return;
    this.Map2Upload.name = file.name;
    this.Map2Upload.content = file;

    //error message should appear after server validation.
    // this.buildForm(this.Map2Upload.name);
  }
  
  public fileUpload() {
    // if (!this.validateMap(this.Map2Upload)) return;

    this.buildForm(this.Map2Upload);

    const formData = new FormData(this.userForm);

    const resultModel = this.mapsService.addMap(this.Map2Upload).subscribe(response=>{ //aad map should return result model, not subscription
      const res = response;
      
      this.uploading = false;
      this.dialogRef.close();
    });

    this.errorMessages?.push("resultModel message");  
  }

  private buildForm(map2Upload: IMapModel){
    let group : any = {};
    group[map2Upload.name] = map2Upload;
    this.userForm = this.formBulder.group(group);
  }

  public selectionChamged(event: any) {
    this.Map2Upload.name = event.target.value;
  }

  private validateMap(map: IMapModel): boolean {
    return map.name !== '' && map.content !== undefined;
  }
}
