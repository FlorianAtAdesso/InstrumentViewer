import { Component, Input, OnInit } from '@angular/core';
import { Iinstrument } from '../iinstrument';

@Component({
  selector: 'app-instrument-list-item',
  templateUrl: './instrument-list-item.component.html',
  styleUrls: ['./instrument-list-item.component.css']
})
export class InstrumentListItemComponent implements OnInit {

  @Input() Instrument!: Iinstrument;
  constructor() { }

  ngOnInit(): void {
  }

}
