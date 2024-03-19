import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrl: './calculator.component.css'
})
export class CalculatorComponent {
  public startvalue: number | undefined;
  public months: number | undefined;

  constructor(private http: HttpClient) { }

  Calculating() {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const body = { "startValue": this.startvalue, "months": this.months }

    this.http.post('https://localhost:7223/Cdb', body, { headers }).subscribe(
      (data: any) => {
        
      },
      (error: any) => {
        console.error('Erro:', error);
      }
    );
  }

}
