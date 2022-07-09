import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app-component/app.component';
import { EntitiesManagerComponent } from './components/entities-manager/entities-manager.component';
import { MapsManagerComponent } from './components/maps-manager/maps-manager.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { MapUploaderDialogComponent } from './components/map-uploader/map-uploader-dialog.component';
import { MaterialModule } from './modules/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MapsManagerComponent,
    EntitiesManagerComponent,
    MapUploaderDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
