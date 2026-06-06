import { Component, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavItem } from '../../models/navigation.model';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, MatIconModule, MatListModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class SidebarComponent {
  protected readonly navItems = signal<NavItem[]>([
    { label: 'Usuarios', icon: 'people', route: '/users' },
    { label: 'Cuadrillas', icon: 'groups', route: '/crew-management' },
    { label: 'Panel Principal', icon: 'dashboard', route: '/dashboard' },
    { label: 'Fichar Asistencia', icon: 'qr_code_scanner', route: '/qr-attendance' },
    { label: 'Sectores y Cultivos', icon: 'grass', route: '/sectors' },
    { label: 'Incidencias', icon: 'bug_report', route: '/incidents' },
    { label: 'Tratamientos', icon: 'science', route: '/treatments' }

  ]);
}
