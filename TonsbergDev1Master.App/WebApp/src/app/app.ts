import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule],
  templateUrl: './app.html',
  styleUrl: './app.sass'
})
export class App {
  protected title = 'VAT Verification';

  countryCode: string = 'DE';
  vatNumber: string = '118856456';
  verificationResult: string | null = null;
  errorMessage: string | null = null;

  constructor(private http: HttpClient) { }

  verifyVat() {
    this.errorMessage = null;
    const url = `${environment.vatApiUrl}?countryCode=${encodeURIComponent(this.countryCode)}&vatId=${encodeURIComponent(this.vatNumber)}`;

    this.http.get(url).subscribe({
      next: (result: any) => {
        this.verificationResult = result.verificationStatus;
      },
      error: (error: any) => {
        this.verificationResult = null;
        this.errorMessage = 'Verification failed.';
        console.error('API error:', error);
      }
    });
  }
}
