import { SensorMapComponent } from './components/dashboard/sensor-map/sensor-map.component';

import { Routes } from '@angular/router';
import { SensorListComponent } from './components/dashboard/sensor-list/sensor-list.component';


export const routes: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    { path: 'dashboard', component: SensorListComponent },
    { path: 'map', component: SensorMapComponent },
    { path: '**', redirectTo: 'dashboard' }
  ];
