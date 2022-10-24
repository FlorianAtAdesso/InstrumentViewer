import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstrumentListRowComponent } from './instrument-list-row.component';

describe('InstrumentListRowComponent', () => {
  let component: InstrumentListRowComponent;
  let fixture: ComponentFixture<InstrumentListRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InstrumentListRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstrumentListRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
