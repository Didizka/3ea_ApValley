import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
declare var google;

@Component({
  selector: 'app-sensor-map',
  templateUrl: './sensor-map.component.html',
  styleUrls: ['./sensor-map.component.scss']
})
export class SensorMapComponent implements OnInit {
  // Sensors
  sensors: any = [];

  // Map
  lat;
  lng;
  map: any;
  markers: any[] = [];

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getAllSensors().subscribe(response => {
      // console.log(response);
      this.sensors = response;
      this.getCurrentPosition();
    });
  }

  // Needs SSL support
  getCurrentPosition() {
    // if (!!navigator.geolocation) {
    //   // Supported
    //   navigator.geolocation.getCurrentPosition(position => {
    //     this.lat = position.coords.latitude;
    //     this.lng = position.coords.longitude;
    //     // console.log(position);
    //     this.initMap();
    //     this.addMarkers();
    //   });
    // } else {
    //   // Not supported, use hardcoded coords of school
    //   this.lat = 51.184742;
    //   this.lng = 4.4410123;
    //   this.initMap();
    //   this.addMarkers();
    // }
    this.lat = 51.184742;
    this.lng = 4.4410123;
    this.initMap();
    this.addMarkers();
  }

  initMap() {
    const mapOptions = {
      center: new google.maps.LatLng(this.lat, this.lng),
      zoom: 13,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
      scrollwheel: false
    };
    this.map = new google.maps.Map(document.getElementById('map'), mapOptions);
  }

  addMarkers() {
    for (const sensor of this.sensors) {
      const location = new google.maps.LatLng(sensor.latitude, sensor.longitude);

      const marker = new google.maps.Marker({
        map: this.map,
        animation: google.maps.Animation.DROP,
        position: location,
        label: sensor.sensorID.toString()
      });
    }
  }

}
