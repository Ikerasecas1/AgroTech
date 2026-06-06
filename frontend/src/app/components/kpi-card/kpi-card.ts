import { Component, input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-kpi-card',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './kpi-card.html',
  styleUrl: './kpi-card.css'
})
export class KpiCardComponent {
  title = input.required<string>();
  value = input.required<string | number>();
  icon = input.required<string>();
  trend = input<string>('');
  accentColor = input<string>('var(--ag-green-500)');
}
