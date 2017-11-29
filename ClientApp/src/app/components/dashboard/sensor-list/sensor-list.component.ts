
import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './sensor-list.component.html',
  styleUrls: ['./sensor-list.component.scss']
})
export class SensorListComponent implements OnInit {
  sensors: any = [];
  url = 'http://parktrack.ddns.net/api/sensors/';

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getAllSensors().subscribe(response => {
      // console.log(response);
      this.sensors = response;
    });
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
