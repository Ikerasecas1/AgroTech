import { Component, signal, computed } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { KpiCardComponent } from '../kpi-card/kpi-card';
import { KpiData } from '../../models/navigation.model';

export interface UserData {
  id: number;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  role: 'Admin' | 'Technician' | 'Foreman' | 'Worker';
  avatarUrl: string | null;
  isActive: boolean;
  lastLogin: string | null;
  linkedWorker: string | null;
  createdAt: string;
}

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatTooltipModule, KpiCardComponent],
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class UsersComponent {
  protected readonly searchQuery = signal('');
  protected readonly selectedRoleFilter = signal<string>('all');

  protected readonly kpiData = signal<KpiData[]>([
    {
      title: 'Usuarios Totales',
      value: 12,
      icon: 'people',
      trend: '↑ 2 nuevos este mes',
      accentColor: 'var(--ag-green-500)'
    },
    {
      title: 'Administradores',
      value: 2,
      icon: 'admin_panel_settings',
      trend: 'Control total del CRM',
      accentColor: '#ef4444'
    },
    {
      title: 'Último Acceso',
      value: 'Hace 5 min',
      icon: 'schedule',
      trend: 'Antonio García · Admin',
      accentColor: 'var(--ag-info)'
    },
    {
      title: 'Cuentas Inactivas',
      value: 1,
      icon: 'person_off',
      trend: '1 cuenta deshabilitada',
      accentColor: 'var(--ag-warning)'
    }
  ]);

  protected readonly users = signal<UserData[]>([
    {
      id: 1,
      username: 'agarcia',
      email: 'antonio.garcia@agrotech.es',
      firstName: 'Antonio',
      lastName: 'García',
      role: 'Admin',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 13:35',
      linkedWorker: null,
      createdAt: '01/01/2026'
    },
    {
      id: 2,
      username: 'mlopez',
      email: 'maria.lopez@agrotech.es',
      firstName: 'María',
      lastName: 'López',
      role: 'Admin',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 10:20',
      linkedWorker: null,
      createdAt: '01/01/2026'
    },
    {
      id: 3,
      username: 'jperez',
      email: 'juan.perez@agrotech.es',
      firstName: 'Juan',
      lastName: 'Pérez',
      role: 'Technician',
      avatarUrl: null,
      isActive: true,
      lastLogin: '05/06/2026 18:45',
      linkedWorker: null,
      createdAt: '15/01/2026'
    },
    {
      id: 4,
      username: 'lrodriguez',
      email: 'lucia.rodriguez@agrotech.es',
      firstName: 'Lucía',
      lastName: 'Rodríguez',
      role: 'Technician',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 08:10',
      linkedWorker: null,
      createdAt: '01/02/2026'
    },
    {
      id: 5,
      username: 'melamrani',
      email: 'mohamed.elamrani@agrotech.es',
      firstName: 'Mohamed',
      lastName: 'El Amrani',
      role: 'Foreman',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 06:30',
      linkedWorker: 'Mohamed El Amrani (QR-012)',
      createdAt: '10/02/2026'
    },
    {
      id: 6,
      username: 'cmartinez',
      email: 'carlos.martinez@agrotech.es',
      firstName: 'Carlos',
      lastName: 'Martínez',
      role: 'Worker',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 06:28',
      linkedWorker: 'Carlos Martínez (QR-001)',
      createdAt: '01/03/2026'
    },
    {
      id: 7,
      username: 'fbenali',
      email: 'fatima.benali@agrotech.es',
      firstName: 'Fatima',
      lastName: 'Benali',
      role: 'Worker',
      avatarUrl: null,
      isActive: true,
      lastLogin: '06/06/2026 06:45',
      linkedWorker: 'Fatima Benali (QR-002)',
      createdAt: '01/03/2026'
    },
    {
      id: 8,
      username: 'aouali',
      email: 'ahmed.ouali@agrotech.es',
      firstName: 'Ahmed',
      lastName: 'Ouali',
      role: 'Worker',
      avatarUrl: null,
      isActive: true,
      lastLogin: '05/06/2026 07:00',
      linkedWorker: 'Ahmed Ouali (QR-003)',
      createdAt: '15/03/2026'
    },
    {
      id: 9,
      username: 'rhernandez',
      email: 'rosa.hernandez@agrotech.es',
      firstName: 'Rosa',
      lastName: 'Hernández',
      role: 'Worker',
      avatarUrl: null,
      isActive: false,
      lastLogin: '20/04/2026 14:30',
      linkedWorker: 'Rosa Hernández (QR-004)',
      createdAt: '01/03/2026'
    }
  ]);

  protected readonly roleColors: Record<string, string> = {
    Admin: '#ef4444',
    Technician: 'var(--ag-info)',
    Foreman: '#8b5cf6',
    Worker: 'var(--ag-green-500)'
  };

  protected readonly roleLabels: Record<string, string> = {
    Admin: 'Administrador',
    Technician: 'Técnico',
    Foreman: 'Encargado',
    Worker: 'Jornalero'
  };

  protected readonly roleIcons: Record<string, string> = {
    Admin: 'admin_panel_settings',
    Technician: 'biotech',
    Foreman: 'supervisor_account',
    Worker: 'badge'
  };

  protected readonly filteredUsers = computed(() => {
    const filter = this.selectedRoleFilter();
    const users = this.users();
    if (filter === 'all') return users;
    return users.filter(u => u.role === filter);
  });

  protected readonly totalActive = computed(() =>
    this.users().filter(u => u.isActive).length
  );

  protected readonly totalInactive = computed(() =>
    this.users().filter(u => !u.isActive).length
  );

  getInitials(firstName: string, lastName: string): string {
    return `${firstName.charAt(0)}${lastName.charAt(0)}`.toUpperCase();
  }

  setRoleFilter(role: string): void {
    this.selectedRoleFilter.set(role);
  }
}
