import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CertificateService } from '../services/certificate.service';

@Component({
  selector: 'app-certificate',
  templateUrl: './certificate.component.html'
})
export class CertificateComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: CertificateService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      certificateName: ['', Validators.required],
      salutation: ['Mr'],
      applicantName: [''],
      applicantFatherName: [''],
      applicantAddress: [''],
      passortNumber: [''],
      currencySymbol: ['$'],
      curAmount: ['91'],
      applicantPropertyIncome: [''],

      applicantFatherSavingAccountBalance: [''],
      applicantFatherBusinessIncome: [''],
      goldJewelleryValue: [''],

      propertyAddress: [''],
      propertyValue: [''],
      vehicle: [''],
      vehicleValue: [''],

      caName: [''],
      partnerNo: [''],
      udin: [''],
      place: [''],
      date: ['']
    });
  }

  submit() {
    if (this.form.invalid) return;

    this.service.generateCertificate(this.form.value)
      .subscribe(blob => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `${this.form.value.certificateName}.docx`;
        a.click();
        window.URL.revokeObjectURL(url);
      });
  }
}
