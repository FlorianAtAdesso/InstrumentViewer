import { Component, Input, OnInit } from '@angular/core';
import { Iinstrument } from '../iinstrument';

@Component({
  selector: 'app-instrument-list-row',
  templateUrl: './instrument-list-row.component.html',
  styleUrls: ['./instrument-list-row.component.css']
})
export class InstrumentListRowComponent implements OnInit {

  @Input() Instruments!: Iinstrument[];


  constructor() { }

  ngOnInit(): void {
  }

}
