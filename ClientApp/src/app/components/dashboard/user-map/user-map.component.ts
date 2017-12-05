import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from '../services/dashboard.service';
declare var google;

@Component({
  selector: 'app-user-map',
  templateUrl: './user-map.component.html',
  styleUrls: ['./user-map.component.scss']
})
export class UserMapComponent implements OnInit {
  // sensor
  sensorID;
  token;
  sensor;
  isVerified = false;

  // Map
  lat;
  lng;
  map: any;
  markers: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: DashboardService
  ) { }

  ngOnInit() {
    this.sensorID = this.route.snapshot.paramMap.get('sensorId');
    this.token = this.route.snapshot.paramMap.get('token');
    this.service.getSensorsByIdWithToken(this.sensorID, this.token).subscribe(response => {
      console.log(response);
      this.isVerified = true;
      if (response !== false) {
        this.sensor = response;
        this.getCurrentPosition();
      }
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
    this.lat = this.sensor.latitude;
    this.lng = this.sensor.longitude;
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
    console.log(document.getElementById('map'));
    this.map = new google.maps.Map(document.getElementById('map'), mapOptions);
  }

  addMarkers() {
    const location = new google.maps.LatLng(this.sensor.latitude, this.sensor.longitude);
    const marker = new google.maps.Marker({
      map: this.map,
      animation: google.maps.Animation.DROP,
      position: location,
      label: this.sensor.sensorID.toString()
    });
  }

}
