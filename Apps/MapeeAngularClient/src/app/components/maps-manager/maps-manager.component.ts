import { Component, OnInit } from '@angular/core';
import { MapsService } from '../../Services/Maps/maps.service';

@Component({
  selector: 'app-maps-manager',
  templateUrl: './maps-manager.component.html',
  styleUrls: ['./maps-manager.component.css'],
})
export class MapsManagerComponent implements OnInit {
  constructor(private readonly MapService: MapsService) {}

  ngOnInit(): void {}
}
