import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'MapeeAngularClient';
  navLinks: any[];

  constructor(private router: Router) {
    this.navLinks = [
      {
        label: 'Entities Manager',
        url: './entities',
        index: 1,
      },
      {
        label: 'Map Manager',
        url: './maps',
        index: 0,
      },
    ];
  }
}
