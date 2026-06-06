import { Component, signal, computed } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { KpiCardComponent } from '../kpi-card/kpi-card';
import { KpiData } from '../../models/navigation.model';

interface CrewData {
  name: string;
  greenhouse: string;
  foreman: string;
  memberCount: number;
  status: 'Active' | 'Disbanded';
  accentColor: string;
}

interface TimeRecord {
  workerName: string;
  qrCode: string;
  checkIn: string;
  checkOut: string | null;
  hoursWorked: string;
}

@Component({
  selector: 'app-crew-management',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatTooltipModule, KpiCardComponent],
  templateUrl: './crew-management.html',
  styleUrl: './crew-management.css'
})
export class CrewManagementComponent {
  protected readonly kpiData = signal<KpiData[]>([
    {
      title: 'Jornaleros Activos Hoy',
      value: 24,
      icon: 'badge',
      trend: '↑ 3 más que ayer',
      accentColor: 'var(--ag-green-500)'
    }
  ]);

  protected readonly crews = signal<CrewData[]>([
    {
      name: 'Cuadrilla Poniente A',
      greenhouse: 'Invernadero Norte',
      foreman: 'Antonio García',
      memberCount: 8,
      status: 'Active',
      accentColor: 'var(--ag-green-500)'
    },
    {
      name: 'Cuadrilla Níjar B',
      greenhouse: 'Invernadero Sur',
      foreman: 'Mohamed El Amrani',
      memberCount: 6,
      status: 'Active',
      accentColor: 'var(--ag-info)'
    },
    {
      name: 'Cuadrilla El Alquián C',
      greenhouse: 'Finca El Alquián',
      foreman: 'María López',
      memberCount: 10,
      status: 'Active',
      accentColor: '#8b5cf6'
    }
  ]);

  protected readonly timeRecords = signal<TimeRecord[]>([
    {
      workerName: 'Carlos Martínez',
      qrCode: 'QR-001',
      checkIn: '06:30',
      checkOut: '14:30',
      hoursWorked: '8h 00m'
    },
    {
      workerName: 'Fatima Benali',
      qrCode: 'QR-002',
      checkIn: '06:45',
      checkOut: '14:15',
      hoursWorked: '7h 30m'
    },
    {
      workerName: 'Ahmed Ouali',
      qrCode: 'QR-003',
      checkIn: '07:00',
      checkOut: null,
      hoursWorked: 'En curso...'
    },
    {
      workerName: 'Rosa Hernández',
      qrCode: 'QR-004',
      checkIn: '06:30',
      checkOut: '14:30',
      hoursWorked: '8h 00m'
    },
    {
      workerName: 'Youssef Amara',
      qrCode: 'QR-005',
      checkIn: '07:15',
      checkOut: null,
      hoursWorked: 'En curso...'
    }
  ]);

}
