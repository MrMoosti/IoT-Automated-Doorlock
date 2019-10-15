import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { DoorStatePage } from './door-state.page';

describe('DoorStatePage', () => {
  let component: DoorStatePage;
  let fixture: ComponentFixture<DoorStatePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [DoorStatePage],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(DoorStatePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
