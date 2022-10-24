import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Iinstrument } from './iinstrument'

@Injectable({
  providedIn: 'root'
})
export class InstrumentService {
  private url: string = 'https://instrumentviewerapi.azurewebsites.net/api/';
  constructor(private http: HttpClient) { }

  getAllInstruments(): Observable<Iinstrument[]> {
    return this.http.get<Iinstrument[]>(this.url + 'GetAllInstrument');
  }
}
