import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';

const MatrterialComponents = [
  MatTabsModule,
  MatListModule,
  MatIconModule,
  MatSidenavModule,
  MatButtonModule,
  MatDialogModule,
  MatToolbarModule,
];

@NgModule({
  imports: [MatrterialComponents],
  exports: [MatrterialComponents],
})
export class MaterialModule {}
