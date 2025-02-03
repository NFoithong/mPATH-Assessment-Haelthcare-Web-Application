// patient.model.ts
import { Recommendation } from './recommendation.model';  // Import Recommendation here

export interface Patient {
  id: string;
  name: string;
  age: number;
  gender: string;
  medicalHistory?: string[];
  recommendations: Recommendation[];
}
