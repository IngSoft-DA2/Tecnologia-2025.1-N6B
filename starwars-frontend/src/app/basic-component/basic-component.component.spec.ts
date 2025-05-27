import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicComponentComponent } from './basic-component.component';

describe('BasicComponentComponent', () => {
  let component: BasicComponentComponent;
  let fixture: ComponentFixture<BasicComponentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BasicComponentComponent]
    });
    fixture = TestBed.createComponent(BasicComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
