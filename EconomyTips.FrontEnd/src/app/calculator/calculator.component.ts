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
  public finalValue: number | undefined;
  public finalValueWithTaxes: number | undefined;

  constructor(public httpClient: HttpClient) { }

  Calculating() {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const body = { "startValue": this.startvalue, "months": this.months }    

    this.httpClient.post('https://localhost:7223/Cdb', body).subscribe(
      (data: any) => {
        this.finalValue = data.finalValue;
        this.finalValueWithTaxes = data.finalValueWithTaxes;
      },
      (error: any) => {
        console.error('Erro:', error);
      }
    );
  }

}
