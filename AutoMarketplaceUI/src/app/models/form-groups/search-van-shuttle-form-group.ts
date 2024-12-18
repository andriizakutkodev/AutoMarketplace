import { BaseSearchFormGroup } from './base-search-form-group';
import { FormControl } from '@angular/forms';

export interface SearchVanShuttleFormGroup extends BaseSearchFormGroup {
  numberOfSeats: FormControl<number>;
}
