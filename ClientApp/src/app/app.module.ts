
import { routes } from './routes';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './components/app/app.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';

import { NgxQRCodeModule } from 'ngx-qrcode2';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SensorListComponent } from './components/dashboard/sensor-list/sensor-list.component';
import { DashboardService } from './components/dashboard/services/dashboard.service';
import { SensorMapComponent } from './components/dashboard/sensor-map/sensor-map.component';
import { NavSidebarComponent } from './components/nav-sidebar/nav-sidebar.component';
import { UserMapComponent } from './components/dashboard/user-map/user-map.component';




@NgModule({
  declarations: [
    AppComponent,
    SensorListComponent,
    NavbarComponent,
    SensorMapComponent,
    NavSidebarComponent,
    UserMapComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpModule,
    NgxQRCodeModule
  ],
  providers: [ DashboardService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
