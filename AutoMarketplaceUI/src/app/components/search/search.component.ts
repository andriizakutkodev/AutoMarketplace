import { Component } from '@angular/core';
import { MatTab, MatTabGroup, MatTabLabel } from '@angular/material/tabs';
import { faCar, faMotorcycle, faVanShuttle } from '@fortawesome/free-solid-svg-icons';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { SearchFormComponent } from '../search-form/search-form.component';
import { VehicleType } from '../../enums/vehicle-type.enum';

@Component({
  selector: 'app-search',
  imports: [
    MatTabGroup,
    MatTab,
    FaIconComponent,
    MatTabLabel,
    SearchFormComponent
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {
  faCar = faCar;
  faMotorcycle = faMotorcycle;
  faVanShuttle  = faVanShuttle;
  vehicleType = VehicleType;
}
