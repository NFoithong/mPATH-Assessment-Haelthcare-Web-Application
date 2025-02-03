import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from '../models/patient.model';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private apiUrl = 'https://your-api-url.com/api/patients'; // Replace with your backend URL

  constructor(private http: HttpClient) { }

  //getPatients(): Observable<Patient[]> {
  //  return this.http.get<Patient[]>(`${this.apiUrl}`);
  //}

  getPatientById(id: string | null): Observable<Patient> {
    return this.http.get<Patient>(`${this.apiUrl}/${id}`);
  }

  getPatients(search: string = '', page: number = 1, pageSize: number = 10): Observable<any> {
    return this.http.get(`${this.apiUrl}/patients`, { params: { search, page, pageSize } });
  }

  getPatientDetails(id: string): Observable<Patient> {
    return this.http.get<Patient>(`${this.apiUrl}/${id}`);
  }

  completeRecommendation(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/recommendations/${id}/complete`, {});
  }

}
