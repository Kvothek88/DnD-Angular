import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterSkills } from './character-skills';

describe('CharacterSkills', () => {
  let component: CharacterSkills;
  let fixture: ComponentFixture<CharacterSkills>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterSkills]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterSkills);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
