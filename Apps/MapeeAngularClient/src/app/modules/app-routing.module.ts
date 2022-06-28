import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EntitiesManagerComponent } from '../components/entities-manager/entities-manager.component';
import { MapsManagerComponent } from '../components/maps-manager/maps-manager.component';

const routes: Routes = [
  { path: 'maps', component: MapsManagerComponent, pathMatch: 'full' },
  { path: 'entities', component: EntitiesManagerComponent, pathMatch: 'full' },
];

export const appRouting = RouterModule.forRoot(routes);

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
