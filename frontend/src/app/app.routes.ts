import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    loadComponent: () =>
      import('./components/auth/auth').then(m => m.AuthComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./components/dashboard/dashboard').then(m => m.DashboardComponent)
  },
  {
    path: 'sectors',
    loadComponent: () =>
      import('./components/sectors/sectors').then(m => m.SectorsComponent)
  },
  {
    path: 'incidents',
    loadComponent: () =>
      import('./components/incidents/incidents').then(m => m.IncidentsComponent)
  },
  {
    path: 'treatments',
    loadComponent: () =>
      import('./components/treatments/treatments').then(m => m.TreatmentsComponent)
  },
  {
    path: 'crew-management',
    loadComponent: () =>
      import('./components/crew-management/crew-management').then(m => m.CrewManagementComponent)
  },
  {
    path: 'users',
    loadComponent: () =>
      import('./components/users/users').then(m => m.UsersComponent)
  },
  {
    path: 'qr-attendance',
    loadComponent: () =>
      import('./components/qr-attendance/qr-attendance').then(m => m.QrAttendanceComponent)
  },
  {
    path: '**',
    redirectTo: 'dashboard'
  }
];
