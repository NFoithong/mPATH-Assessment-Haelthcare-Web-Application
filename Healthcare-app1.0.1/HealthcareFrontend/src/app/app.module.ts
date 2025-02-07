import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/Login/login.component';
import { DashboardComponent } from './components/Dashboard/dashboard.component';
import { PatientDetailComponent } from './components/Patient-detail/patient-detail.component';
import { AuthGuard } from './guards/auth.guard';
import { AuthInterceptor } from './interceptor/auth.interceptor';
import { SanitizeHtmlPipe } from './pipes/sanitize-html.pipe'; // Import the pipe

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    PatientDetailComponent,
    SanitizeHtmlPipe // Declare the pipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    AuthGuard,
    provideHttpClient(withInterceptors([AuthInterceptor])) // Use the functional interceptor
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
