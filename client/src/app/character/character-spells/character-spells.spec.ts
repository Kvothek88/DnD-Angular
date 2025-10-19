import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterSpells } from './character-spells';

describe('CharacterSpells', () => {
  let component: CharacterSpells;
  let fixture: ComponentFixture<CharacterSpells>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterSpells]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterSpells);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
