import { FormControl } from '@angular/forms';

export interface BaseSearchFormGroup {
  make: FormControl<string>;
  model: FormControl<string>;
  priceUpTo: FormControl<number>;
  country: FormControl<string>;
}
