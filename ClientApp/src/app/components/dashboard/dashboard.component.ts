import { DashboardService } from './../services/dashboard.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  title = 'ParkTrack Admin Dashboard';
  sensors: any = [];
  url = 'http://localhost:5050/api/sensors/';

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getAllSensors().subscribe(response => {
      console.log(response);
      this.sensors = response;
    });
  }

}
