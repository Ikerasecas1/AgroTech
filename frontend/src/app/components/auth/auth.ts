import { Component, signal, computed } from '@angular/core';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';

export type AuthMode = 'login' | 'register' | 'forgot';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatRippleModule],
  templateUrl: './auth.html',
  styleUrl: './auth.css'
})
export class AuthComponent {
  protected readonly currentMode = signal<AuthMode>('login');
  protected readonly isLoading = signal<boolean>(false);
  protected readonly errorMessage = signal<string | null>(null);

  protected readonly modeTitle = computed(() => {
    switch (this.currentMode()) {
      case 'login': return 'Bienvenido de nuevo';
      case 'register': return 'Crear cuenta';
      case 'forgot': return 'Recuperar contraseña';
    }
  });

  protected readonly modeSubtitle = computed(() => {
    switch (this.currentMode()) {
      case 'login': return 'Accede al panel de control de AgroTech';
      case 'register': return 'Únete al sistema de gestión inteligente';
      case 'forgot': return 'Te enviaremos un enlace de recuperación';
    }
  });

  constructor(private router: Router) {}

  switchMode(mode: AuthMode): void {
    this.currentMode.set(mode);
    this.errorMessage.set(null);
  }

  // Simulated Submit
  onSubmit(event: Event): void {
    event.preventDefault();
    this.isLoading.set(true);
    this.errorMessage.set(null);

    // Simulate network delay
    setTimeout(() => {
      this.isLoading.set(false);
      
      const mode = this.currentMode();
      if (mode === 'login' || mode === 'register') {
        // Success -> Go to dashboard
        this.router.navigate(['/dashboard']);
      } else if (mode === 'forgot') {
        // Show simulated success message or switch back to login
        this.switchMode('login');
      }
    }, 1500);
  }
}
