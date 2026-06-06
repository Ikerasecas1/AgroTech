import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-incidents',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './incidents.html',
  styleUrl: './incidents.css'
})
export class IncidentsComponent {}
