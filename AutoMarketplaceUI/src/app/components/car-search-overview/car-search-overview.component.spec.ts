import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarSearchOverviewComponent } from './car-search-overview.component';

describe('CarSearchOverviewComponent', () => {
  let component: CarSearchOverviewComponent;
  let fixture: ComponentFixture<CarSearchOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarSearchOverviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarSearchOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
