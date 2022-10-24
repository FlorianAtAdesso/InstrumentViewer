import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InstrumentInfoComponent } from './instrument-info/instrument-info.component';

const routes: Routes = [
  { path: 'instrument', component: InstrumentInfoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
