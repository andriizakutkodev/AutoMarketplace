import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { SearchComponent } from './components/search/search.component';
import { CarSearchOverviewComponent } from './components/car-search-overview/car-search-overview.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, SearchComponent, CarSearchOverviewComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AutoMarketplaceUI';
  isRouteActive = false;

  constructor(private router: Router) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isRouteActive = event.url !== '/';
      }
    });
  }
}
