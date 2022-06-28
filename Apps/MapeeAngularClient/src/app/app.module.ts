import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app-component/app.component';
import { EntitiesManagerComponent } from './components/entities-manager/entities-manager.component';
import { MapsManagerComponent } from './components/maps-manager/maps-manager.component';
import { AppRoutingModule } from './modules/app-routing.module';

@NgModule({
  declarations: [AppComponent, MapsManagerComponent, EntitiesManagerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
