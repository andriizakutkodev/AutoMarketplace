import { FormControl } from '@angular/forms';
import { BaseSearchFormGroup } from './base-search-form-group';

export interface SearchMotorcycleFormGroup extends BaseSearchFormGroup {
  bodyType: FormControl<string>;
}
