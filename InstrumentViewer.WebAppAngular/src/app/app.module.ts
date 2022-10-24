import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule} from './app-routing.module'
import { AppComponent } from './app.component';
import { InstrumentInfoComponent } from './instrument-info/instrument-info.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { InstrumentListComponent } from './instrument-list/instrument-list.component';
import { InstrumentListItemComponent } from './instrument-list-item/instrument-list-item.component';
import { InstrumentListRowComponent } from './instrument-list-row/instrument-list-row.component';
import { CreateInstrumentComponent } from './create-instrument/create-instrument.component';
import { MatFormFieldModule, } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule  } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { CreateInstrumentDialogComponent } from './create-instrument-dialog/create-instrument-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    InstrumentInfoComponent,
    InstrumentListComponent,
    InstrumentListItemComponent,
    InstrumentListRowComponent,
    CreateInstrumentComponent,
    CreateInstrumentDialogComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    AppRoutingModule,
    RouterModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatProgressBarModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
