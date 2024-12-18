import { Component, Input, OnInit } from '@angular/core';
import { VehicleType } from '../../enums/vehicle-type.enum';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchCarFormGroup } from '../../models/form-groups/search-car-form-group';
import { SearchMotorcycleFormGroup } from '../../models/form-groups/search-motorcycle-form-group';
import { SearchVanShuttleFormGroup } from '../../models/form-groups/search-van-shuttle-form-group';
import { MatFormField } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { CarVehicleMakeEnum } from '../../enums/car-vehicle-make.enum';
import { MotorcycleVehicleMakeEnum } from '../../enums/motorcycle-vehicle-make.enum';
import { VanShuttleVehicleMakeEnum } from '../../enums/van-shuttle-vehicle-make.enum';
import { carModelsByMake } from '../../constants/car-models-by-make';
import { priceUpTo } from '../../constants/price-up-to';
import { motorcycleModelsByMake } from '../../constants/motorcycle-models-by-make';
import { vanShuttleModelsByMake } from '../../constants/van-shuttle-models-by-make';
import { firstRegistrationFrom } from '../../constants/first-registration-from';
import { MatButton } from '@angular/material/button';
import { countries } from '../../constants/countries';
import { motorcycleBodyType } from '../../constants/motorcycle-body-type';
import { vanShuttleNumberOfSeats } from '../../constants/van-shuttle-number-of-seats';

@Component({
  selector: 'app-search-form',
  imports: [
    FormsModule,
    MatFormField,
    ReactiveFormsModule,
    MatSelect,
    MatOption,
    MatButton
  ],
  templateUrl: './search-form.component.html',
  styleUrl: './search-form.component.scss'
})
export class SearchFormComponent implements OnInit {
  @Input() vehicleType!: VehicleType;

  searchForm!: FormGroup;
  vehicleMakes!: (string | (CarVehicleMakeEnum | MotorcycleVehicleMakeEnum | VanShuttleVehicleMakeEnum))[];
  priceUpToList = priceUpTo;
  firstRegistrationFromList = firstRegistrationFrom;
  countries  = countries;
  motorcycleBodyTypeList = motorcycleBodyType;
  vanShuttleNumberOfSeatsList = vanShuttleNumberOfSeats;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.initData();
  }

  get vehicleModels() {
    const make = this.searchForm.controls['make'].value as string;
    let enumValue: (CarVehicleMakeEnum | MotorcycleVehicleMakeEnum | VanShuttleVehicleMakeEnum);

    switch (this.vehicleType) {
      case VehicleType.Car:
        enumValue = CarVehicleMakeEnum[make as keyof typeof CarVehicleMakeEnum];
        return carModelsByMake[enumValue];
      case VehicleType.Motorcycle:
        enumValue = MotorcycleVehicleMakeEnum[make as keyof typeof MotorcycleVehicleMakeEnum];
        return motorcycleModelsByMake[enumValue];
      case VehicleType.VanShuttle:
        enumValue = VanShuttleVehicleMakeEnum[make as keyof typeof VanShuttleVehicleMakeEnum];
        return vanShuttleModelsByMake[enumValue];
    }
  }

  onMakeFormFieldValueChange(){
    return this.searchForm.controls['make'].value as string === '' ?
      this.searchForm.controls['model'].disable() : this.searchForm.controls['model'].enable();
  }

  private initData() {
    switch (this.vehicleType) {
      case VehicleType.Car:
        this.vehicleMakes = this.vehicleMakes = Object.keys(CarVehicleMakeEnum).filter(key => isNaN(Number(key)));

        this.searchForm = this.formBuilder.group({
          make: new FormControl(''),
          model: new FormControl({ value: '', disabled: true }),
          priceUpTo: new FormControl(0),
          firstRegistrationFrom: new FormControl(0),
          country: new FormControl('')
        } as SearchCarFormGroup);
        break;
      case VehicleType.Motorcycle:
        this.vehicleMakes = Object.keys(MotorcycleVehicleMakeEnum).filter(key => isNaN(Number(key)));

        this.searchForm = this.formBuilder.group({
          make: new FormControl(''),
          model: new FormControl({ value: '', disabled: true }),
          priceUpTo: new FormControl(0),
          bodyType: new FormControl(''),
          country: new FormControl('')
        } as SearchMotorcycleFormGroup);
        break;
      case VehicleType.VanShuttle:
        this.vehicleMakes = Object.keys(VanShuttleVehicleMakeEnum).filter(key => isNaN(Number(key)));

        this.searchForm = this.formBuilder.group({
          make: new FormControl(''),
          model: new FormControl({ value: '', disabled: true }),
          priceUpTo: new FormControl(0),
          numberOfSeats: new FormControl(0),
          country: new FormControl('')
        } as SearchVanShuttleFormGroup);
        break;
    }
  }
}
