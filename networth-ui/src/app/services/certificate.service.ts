import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CertificateDto } from '../models/certificate.model';

@Injectable({ providedIn: 'root' })
export class CertificateService {

  private apiUrl = 'https://localhost:7284/api/docx/generate';

  constructor(private http: HttpClient) {}

  generateCertificate(dto: CertificateDto) {
    return this.http.post(this.apiUrl, dto, {
      responseType: 'blob'
    });
  }
}
