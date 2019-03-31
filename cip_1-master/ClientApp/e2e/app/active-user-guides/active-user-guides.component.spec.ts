import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveUserGuidesComponent } from './active-user-guides.component';

describe('ActiveUserGuidesComponent', () => {
  let component: ActiveUserGuidesComponent;
  let fixture: ComponentFixture<ActiveUserGuidesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActiveUserGuidesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveUserGuidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
