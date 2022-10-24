import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInstrumentDialogComponent } from './create-instrument-dialog.component';

describe('CreateInstrumentDialogComponent', () => {
  let component: CreateInstrumentDialogComponent;
  let fixture: ComponentFixture<CreateInstrumentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateInstrumentDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInstrumentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
