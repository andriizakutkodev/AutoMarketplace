import { VanShuttleVehicleMakeEnum } from '../enums/van-shuttle-vehicle-make.enum';

export const vanShuttleModelsByMake: Record<VanShuttleVehicleMakeEnum, string[]> = {
  [VanShuttleVehicleMakeEnum.Ford]: [
    'Transit 150',
    'Transit 250',
    'Transit 350',
    'Transit Connect',
    'E-350 Super Duty',
    'E-450 Super Duty',
    'Transit Wagon',
    'Transit Custom',
    'Tourneo Custom'
  ]
}
