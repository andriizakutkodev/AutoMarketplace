import { FormControl } from '@angular/forms';
import { BaseSearchFormGroup } from './base-search-form-group';

export interface SearchCarFormGroup extends BaseSearchFormGroup {
  firstRegistrationFrom: FormControl<number>;
}
