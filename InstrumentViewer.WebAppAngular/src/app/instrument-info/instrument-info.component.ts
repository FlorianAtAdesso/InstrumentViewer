import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Iinstrument } from '../iinstrument';
import { InstrumentService } from '../instrument.service';

@Component({
  selector: 'app-instrument-info',
  templateUrl: './instrument-info.component.html',
  styleUrls: ['./instrument-info.component.css']
})
export class InstrumentInfoComponent implements OnInit {

  constructor(private service: InstrumentService, private route: ActivatedRoute) {

    

    this.route.params.subscribe(x => {
      console.log(x['name']);
      this.GetInstrument(x['name'])
    });
}

  public Instrument: Iinstrument | undefined;

  ngOnInit(): void {
    
  }

  private GetInstrument(name: string) {
    this.service.GetItstuemntByName(name).subscribe(data => {
      console.log(data);
      this.Instrument = data;
    });
  }

}
