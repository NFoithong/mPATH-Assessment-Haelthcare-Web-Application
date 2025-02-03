import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../models/patient.model';
import { Recommendation } from '../../models/recommendation.model'; // Assuming a separate model for recommendations

@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html',
  styleUrls: ['./patient-detail.component.scss']
})
export class PatientDetailComponent implements OnInit {
  patient: Patient | null = null; // Ensure patient follows the `Patient` model

  constructor(
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) this.loadPatientDetails(id);
  }

  loadPatientDetails(id: string): void {
    this.patientService.getPatientDetails(id).subscribe({
      next: (response: Patient) => {
        this.patient = response;
      },
      error: (error) => {
        console.error('Error loading patient details:', error);
      }
    });
  }

  markCompleted(recommendationId: number): void {
    if (!this.patient) return;

    this.patientService.completeRecommendation(recommendationId).subscribe(() => {
      const recommendation = this.patient?.recommendations.find((r: Recommendation) => r.id === recommendationId);
      if (recommendation) {
        recommendation.isCompleted = true;
      }
    });
  }
}
