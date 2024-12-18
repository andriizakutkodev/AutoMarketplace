import { Component } from '@angular/core';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';
import { MatChip, MatChipSet } from '@angular/material/chips';
import { faChargingStation, faCarTunnel, faTreeCity, faPeopleGroup, faMagnifyingGlassDollar } from '@fortawesome/free-solid-svg-icons';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-car-search-overview',
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    MatChipSet,
    MatChip,
    FaIconComponent,
    MatCardActions,
    MatButton
  ],
  templateUrl: './car-search-overview.component.html',
  styleUrl: './car-search-overview.component.scss'
})
export class CarSearchOverviewComponent {
  faChargingStation = faChargingStation;
  faCarTunnel = faCarTunnel;
  faTreeCity = faTreeCity;
  faPeopleGroup = faPeopleGroup;
  faMagnifyingGlassDollar = faMagnifyingGlassDollar;
}
