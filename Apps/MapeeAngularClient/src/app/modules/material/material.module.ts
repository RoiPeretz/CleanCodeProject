import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';

const MatrterialComponents = [
  MatTabsModule,
  MatListModule,
  MatIconModule,
  MatSidenavModule,
  MatButtonModule,
  MatDialogModule,
  MatToolbarModule,
  MatInputModule,
  MatGridListModule,
  MatFormFieldModule
];

@NgModule({
  imports: [MatrterialComponents],
  exports: [MatrterialComponents],
})
export class MaterialModule {}
