import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { faArrowRight, faStar, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { jwtDecode } from 'jwt-decode';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { MatButton } from '@angular/material/button';
import { MatLabel } from '@angular/material/form-field';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  imports: [
    FaIconComponent,
    MatButton,
    MatLabel
  ]
})
export class HeaderComponent implements OnInit, OnDestroy {
  faStar = faStar;
  faArrowRight = faArrowRight;
  faArrowLeft = faArrowLeft;

  isAuthenticated = false;
  userName: string | null = null;

  private authSubscription!: Subscription;
  private resizeObserver!: ResizeObserver;

  constructor(private authService: AuthService, private router: Router) {
  }

  ngOnInit() {
    this.authSubscription = this.authService.authToken$.subscribe((token) => {
      this.isAuthenticated = !!token;
      if (this.isAuthenticated) {
        this.userName = this.authService.getAuthToken()
          ? this.extractUserName(this.authService.getAuthToken()!)
          : null;
      } else {
        this.userName = null;
        this.handleUnauthenticatedState();
      }
    });

    this.handleResizeObserver();
    document.addEventListener('click', this.handleDocumentClick.bind(this));
  }

  toggleHamburgerMenu(event?: MouseEvent) {
    event?.stopPropagation();
    const menuContainer = document.getElementById('menu-container');
    menuContainer?.classList.toggle('active-general-menu');
  }

  toggleUserMenu(event?: MouseEvent) {
    event?.stopPropagation();
    const menuContainer = document.getElementById('menu-container');
    menuContainer?.classList.toggle('active-user-menu');
  }

  onLoginClick() {
    this.router.navigate(['login']);
  }

  onLogoutClick() {
    this.authService.clearAuthToken();
  }

  private extractUserName(token: string): string {
    const decodedToken = jwtDecode(token) as { email: string };
    return decodedToken.email;
  }

  private handleUnauthenticatedState() {
    const menuContainer = document.getElementById('menu-container');
    menuContainer?.classList.remove('active-user-menu');
  }

  private handleResizeObserver() {
    const menuContainer = document.getElementById('menu-container');
    const checkbox = document.getElementById('checkbox') as HTMLInputElement;

    this.resizeObserver = new ResizeObserver(() => {
      if (window.innerWidth > 1024) {
        menuContainer?.classList.remove('active-general-menu');
        if (checkbox) checkbox.checked = false;
      }
    });

    this.resizeObserver.observe(document.body);
  }

  private handleDocumentClick(event: MouseEvent) {
    const menuContainer = document.getElementById('menu-container');
    const hamburgerContainer = document.getElementById('hamburger-container');
    const checkbox = document.getElementById('checkbox') as HTMLInputElement;

    if (menuContainer && !menuContainer.contains(event.target as Node) && !hamburgerContainer?.contains(event.target as Node)) {
      menuContainer.classList.remove('active-general-menu', 'active-user-menu');
      if (checkbox) checkbox.checked = false;
    }
  }

  ngOnDestroy() {
    this.authSubscription.unsubscribe();
    this.resizeObserver.disconnect();
    document.removeEventListener('click', this.handleDocumentClick.bind(this));
  }
}
