import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { Iinstrument } from './iinstrument'

@Injectable({
  providedIn: 'root'
})
export class InstrumentService {
  private url: string = 'http://localhost:7245/api/';

  constructor(private http: HttpClient) {
  }

  public GetItstuemnts(): Observable<Iinstrument[]> {
    return this.http.get<Iinstrument[]>(this.url + 'GetAllInstrument')
  }


  public GetItstuemntByName(Name: string): Observable<Iinstrument> {
    return this.http.get<Iinstrument>(this.url + 'GetInstrument?id=' + Name);
  }

  public CreateInstument(instrument: Iinstrument) {
    const headers = { 'Authorization': 'Bearer my-token', 'My-Custom-Header': 'foobar' };
    const body = JSON.stringify(instrument);
    console.log(body);
    console.log(this.url + 'AddInstrument');

    this.http.post<any>(this.url + 'AddInstrument', body).subscribe(x => console.log(x));
  }
}
