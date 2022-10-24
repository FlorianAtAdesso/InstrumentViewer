import { Component, OnInit } from '@angular/core';
import { Iinstrument } from '../iinstrument';
import { InstrumentService } from '../instrument.service';

@Component({
  selector: 'app-instrument-list',
  templateUrl: './instrument-list.component.html',
  styleUrls: ['./instrument-list.component.css']
})
export class InstrumentListComponent implements OnInit {

  public InstrumentsRows: Iinstrument[][] = [];
  constructor(private service: InstrumentService) {
    service.GetItstuemnts().subscribe(data => {
      console.log(data);
      for (var i = 0; i < data.length; i++) {
        let currentRowIndex = Math.floor(i / 3);
        if (this.InstrumentsRows[currentRowIndex] == undefined) {
          this.InstrumentsRows.push([]);
        }
        this.InstrumentsRows[currentRowIndex].push(data[i]);
      }
    })
  }

  ngOnInit(): void {
  }

}
