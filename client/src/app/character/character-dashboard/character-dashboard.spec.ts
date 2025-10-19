import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterDashboard } from './character-dashboard';

describe('CharacterDashboard', () => {
  let component: CharacterDashboard;
  let fixture: ComponentFixture<CharacterDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterDashboard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterDashboard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
