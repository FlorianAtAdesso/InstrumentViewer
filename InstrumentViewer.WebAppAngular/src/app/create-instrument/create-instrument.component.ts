import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateInstrumentDialogComponent } from '../create-instrument-dialog/create-instrument-dialog.component';
import { Iinstrument } from '../iinstrument';
import { InstrumentService } from '../instrument.service';

@Component({
  selector: 'app-create-instrument',
  templateUrl: './create-instrument.component.html',
  styleUrls: ['./create-instrument.component.css']
})
export class CreateInstrumentComponent implements OnInit {

  public Slots: number = 0;
  public Price: number = 0;
  public DateModel: string = "" ;

  public InstumentModel: Iinstrument = new Iinstrument("Test", 0, "", "");
  constructor(public dialog: MatDialog, public instrumentService: InstrumentService) { }

  ngOnInit(): void {
  }

  public Log() {

    let RealseDate = this.formatDate(new Date(this.DateModel));

    this.InstumentModel.Price = this.Price + "€";
    this.InstumentModel.Slots = this.Slots;
    this.InstumentModel.RealseDate = RealseDate;

    //console.log(this.InstumentModel);

    let dialogRef = this.dialog.open(CreateInstrumentDialogComponent, {
      data: this.InstumentModel
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.instrumentService.CreateInstument(this.InstumentModel);
      } else {
        console.log("not creating Instument");
      }

    });
  }




  private padTo2Digits(num: number) {
    return num.toString().padStart(2, '0');
  }

  private formatDate(date: Date) {
    return [
      this.padTo2Digits(date.getDate()),
      this.padTo2Digits(date.getMonth() + 1),
      date.getFullYear(),
    ].join('.');
  }
}
