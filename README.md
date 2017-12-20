# README ParkTrack #

This project contains backend written in ASP.NET WebApi's and Admin Dashboard written in Angular 4


### Project Description ###

* The project aims at helping parents finding their children in case they get lost. The backend has API's to communicate with external GPS-trackers to get their current location
* The admin channel of communication uses devices serial numbers to CRUD the data and an admin token to authorize to the server, since we do not work with user accounts or profiles
* The public channel can only get the location of the physical device they get in their hands. At this point the QR code is scanned by the admins / device issuers and the customer token gets active for 12 hours, exact time the battery can feed the device.
* Customers can then just scan their QR code to display their child's location on the map, add multiple devices to their map in case they have multiple children.
* After 12 hours the token expires and gives no longer access to the parent to see the device'c location. At this point they should return the devices to the admins / issuers and before the next rental the token gets regenerated,to give 12 hours of access to new users
* All this is done to work without users accounts and still provide a high level of security protecting such sensitive data as your child's location

