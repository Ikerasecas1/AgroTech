import { Component, signal } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { KpiCardComponent } from '../kpi-card/kpi-card';
import { KpiData } from '../../models/navigation.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MatIconModule, KpiCardComponent],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class DashboardComponent {
  protected readonly kpiData = signal<KpiData[]>([
    {
      title: 'Hectáreas Activas',
      value: '12.5 ha',
      icon: 'landscape',
      trend: '↑ 2 sectores nuevos',
      accentColor: 'var(--ag-green-500)'
    },
    {
      title: 'Alertas de Plagas',
      value: 3,
      icon: 'bug_report',
      trend: '2 en revisión',
      accentColor: 'var(--ag-warning)'
    },
    {
      title: 'Tratamientos Pendientes',
      value: 5,
      icon: 'science',
      trend: '1 plazo de seguridad activo',
      accentColor: 'var(--ag-info)'
    },
    {
      title: 'Cultivos Activos',
      value: 8,
      icon: 'grass',
      trend: '↑ 3 este mes',
      accentColor: 'var(--ag-success)'
    }
  ]);

  protected readonly recentActivity = signal([
    {
      icon: 'bug_report',
      iconColor: 'var(--ag-warning)',
      title: 'Mosca blanca detectada',
      subtitle: 'Invernadero Norte · Tomate Cherry',
      time: 'Hace 2 horas'
    },
    {
      icon: 'science',
      iconColor: 'var(--ag-info)',
      title: 'Suelta de Amblyseius californicus',
      subtitle: 'Sector Sur · Pimiento California',
      time: 'Hace 5 horas'
    },
    {
      icon: 'eco',
      iconColor: 'var(--ag-green-400)',
      title: 'Nuevo cultivo registrado',
      subtitle: 'Pepino Almería · Finca El Alquián',
      time: 'Ayer'
    },
    {
      icon: 'check_circle',
      iconColor: 'var(--ag-success)',
      title: 'Incidencia resuelta',
      subtitle: 'Araña roja · Invernadero Poniente',
      time: 'Hace 2 días'
    }
  ]);
}
