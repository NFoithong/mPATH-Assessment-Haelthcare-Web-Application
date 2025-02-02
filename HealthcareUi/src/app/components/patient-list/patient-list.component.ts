////Create Patient Component

import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {
  patients = [];
  filteredPatients = [];
  selectedPatient: any = null;

  constructor(private patientService: PatientService) { }

  ngOnInit() {
    this.patientService.getPatients().subscribe(data => {
      this.patients = data;
      this.filteredPatients = data;
    });
  }

  search(event: any) {
    const query = event.target.value.toLowerCase();
    this.filteredPatients = this.patients.filter(patient => patient.name.toLowerCase().includes(query));
  }

  viewDetails(patient: any) {
    this.selectedPatient = patient;
  }
}



//import { Component, OnInit } from '@angular/core';
//import { PatientService } from '../../services/patient.service';

//@Component({
//  selector: 'app-patient-list',
//  templateUrl: './patient-list.component.html',
//  styleUrls: ['./patient-list.component.scss']
//})
//export class PatientListComponent implements OnInit {
//  patients: any[] = [];

//  constructor(private patientService: PatientService) { }

//  ngOnInit(): void {
//    this.patientService.getPatients().subscribe(data => {
//      this.patients = data;
//    });
//  }
//}
