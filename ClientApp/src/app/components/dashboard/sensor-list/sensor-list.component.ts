
import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './sensor-list.component.html',
  styleUrls: ['./sensor-list.component.scss']
})
export class SensorListComponent implements OnInit {
  sensors: any = [];
  // url = 'http://parktrack-admin.ddns.net/user-map/';
  url = 'http://localhost:5050/api/sensors/';

  constructor(private dashboardService: DashboardService, private router: Router) { }

  ngOnInit() {
    this.dashboardService.getAllSensors().subscribe(response => {
      // console.log(response);
      this.sensors = response;
    });
  }

  GoTo(sensorID, token) {
    // console.log(sensorID);
    // console.log(token);
    this.router.navigate(['/user-map', sensorID, token]);
  }

  // goToDetailsPage(sensor: any) {
  //   console.log(sensor);
  // }

  // goToEditPage(sensor: any) {
  //   console.log(sensor);
  // }

  // goToDeletePage(sensor: any) {
  //   console.log(sensor);
  // }
}
