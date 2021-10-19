import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarjetaDebitoComponent } from './tarjeta-debito.component';

describe('TarjetaDebitoComponent', () => {
  let component: TarjetaDebitoComponent;
  let fixture: ComponentFixture<TarjetaDebitoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TarjetaDebitoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TarjetaDebitoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
