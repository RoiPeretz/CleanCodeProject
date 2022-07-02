import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app-component/app.component';
import { EntitiesManagerComponent } from './components/entities-manager/entities-manager.component';
import { MapsManagerComponent } from './components/maps-manager/maps-manager.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MapUploaderDialogComponent } from './components/map-uploader/map-uploader-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';

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
    MatTabsModule,
    MatListModule,
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    MatDialogModule,
    MatToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
