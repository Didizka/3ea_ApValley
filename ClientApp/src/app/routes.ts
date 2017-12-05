import { SensorMapComponent } from './components/dashboard/sensor-map/sensor-map.component';

import { Routes } from '@angular/router';
import { SensorListComponent } from './components/dashboard/sensor-list/sensor-list.component';
import { UserMapComponent } from './components/dashboard/user-map/user-map.component';


export const routes: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    { path: 'dashboard', component: SensorListComponent },
    { path: 'map', component: SensorMapComponent },
    { path: 'user-map/:sensorId/:token', component: UserMapComponent },
    { path: '**', redirectTo: 'dashboard' }
  ];
