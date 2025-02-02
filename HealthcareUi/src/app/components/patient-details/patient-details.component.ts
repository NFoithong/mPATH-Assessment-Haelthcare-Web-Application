
import { Component, Input } from '@angular/core';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent {
  @Input() patient: any;

  constructor(private patientService: PatientService) { }

  updateRecommendation(rec: any) {
    this.patientService.updateRecommendation(this.patient.id, rec).subscribe();
  }

  goBack() {
    this.patient = null;
  }
}
