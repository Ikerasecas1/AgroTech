import { Component, signal, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

export type PermissionStatus = 'pending' | 'granted' | 'denied';
export type FeedbackStatus = 'idle' | 'processing' | 'success' | 'error';

@Component({
  selector: 'app-qr-attendance',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatButtonModule, MatProgressSpinnerModule],
  templateUrl: './qr-attendance.html',
  styleUrl: './qr-attendance.css'
})
export class QrAttendanceComponent implements OnInit, OnDestroy {
  // Estado de permisos (simulado)
  protected readonly cameraPermission = signal<PermissionStatus>('pending');
  protected readonly gpsPermission = signal<PermissionStatus>('pending');

  // Estado del escáner visual
  protected readonly isScanning = signal<boolean>(false);
  protected readonly feedbackStatus = signal<FeedbackStatus>('idle');
  protected readonly feedbackMessage = signal<string>('');

  // Reloj
  protected readonly currentTime = signal<string>('');
  private timeInterval: any;

  ngOnInit() {
    this.updateTime();
    this.timeInterval = setInterval(() => this.updateTime(), 1000);
    
    // Simular petición de permisos al iniciar
    setTimeout(() => {
      this.cameraPermission.set('granted');
      this.gpsPermission.set('granted');
      this.isScanning.set(true);
    }, 1500);
  }

  ngOnDestroy() {
    if (this.timeInterval) {
      clearInterval(this.timeInterval);
    }
  }

  private updateTime() {
    const now = new Date();
    const timeString = now.toLocaleTimeString('es-ES', { 
      hour: '2-digit', 
      minute: '2-digit',
      second: '2-digit' 
    });
    this.currentTime.set(timeString);
  }

  // --- Controles del Simulador ---

  /**
   * Simula el flujo completo de un fichaje exitoso
   */
  simulateValidScan(type: 'static' | 'dynamic') {
    if (!this.checkPermissions()) return;

    this.isScanning.set(false);
    this.feedbackStatus.set('processing');
    this.feedbackMessage.set('Validando ubicación y código QR...');

    setTimeout(() => {
      this.feedbackStatus.set('success');
      this.feedbackMessage.set('Fichaje procesado correctamente.');
      
      this.resetScannerAfterDelay();
    }, 1500);
  }

  /**
   * Simula un fichaje fuera de rango (Fake GPS)
   * Nota: Arquitectónicamente, al empleado NO se le dice que ha fallado.
   * Se le muestra el mensaje genérico de éxito, pero internamente 
   * el backend avisa al administrador.
   */
  simulateFakeGps() {
    if (!this.checkPermissions()) return;

    this.isScanning.set(false);
    this.feedbackStatus.set('processing');
    this.feedbackMessage.set('Validando ubicación y código QR...');

    setTimeout(() => {
      // Magia: ¡Mismo feedback visual que un fichaje válido!
      this.feedbackStatus.set('success');
      this.feedbackMessage.set('Fichaje procesado.');
      
      console.warn("ALERTA BACKEND: Trabajador detectado fuera de rango. Alerta enviada al Administrador en segundo plano.");

      this.resetScannerAfterDelay();
    }, 1500);
  }

  /**
   * Simula un error genérico (ej. sin internet, código inválido)
   */
  simulateError() {
    if (!this.checkPermissions()) return;

    this.isScanning.set(false);
    this.feedbackStatus.set('processing');
    this.feedbackMessage.set('Procesando...');

    setTimeout(() => {
      this.feedbackStatus.set('error');
      this.feedbackMessage.set('No se pudo procesar. Inténtalo de nuevo.');
      
      this.resetScannerAfterDelay();
    }, 1500);
  }

  // --- Métodos Auxiliares ---

  private checkPermissions(): boolean {
    if (this.cameraPermission() !== 'granted' || this.gpsPermission() !== 'granted') {
      alert("Se requieren permisos de cámara y ubicación.");
      return false;
    }
    return true;
  }

  private resetScannerAfterDelay() {
    setTimeout(() => {
      this.feedbackStatus.set('idle');
      this.isScanning.set(true);
    }, 3000);
  }
}
