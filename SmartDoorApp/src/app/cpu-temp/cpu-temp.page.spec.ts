import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { CpuTempPage } from './cpu-temp.page';

describe('CpuTempPage', () => {
  let component: CpuTempPage;
  let fixture: ComponentFixture<CpuTempPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CpuTempPage],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(CpuTempPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
