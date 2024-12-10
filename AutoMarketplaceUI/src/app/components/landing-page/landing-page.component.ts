import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { FaIconComponent, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faArrowDown } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-landing-page',
  imports: [
    MatButton,
    FaIconComponent,
    FontAwesomeModule,
  ],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent {
  faArrowDown = faArrowDown;
}
