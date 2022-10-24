import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateInstrumentComponent } from './create-instrument/create-instrument.component';
import { InstrumentInfoComponent } from './instrument-info/instrument-info.component';
import { InstrumentListComponent } from './instrument-list/instrument-list.component';

const routes: Routes = [
  { path: 'instrument/:name', component: InstrumentInfoComponent },
  { path: 'instrument', component: InstrumentListComponent },
  { path: 'create', component: CreateInstrumentComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
