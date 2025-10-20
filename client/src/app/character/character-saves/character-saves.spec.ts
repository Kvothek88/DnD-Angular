import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterSaves } from './character-saves';

describe('CharacterSaves', () => {
  let component: CharacterSaves;
  let fixture: ComponentFixture<CharacterSaves>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterSaves]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterSaves);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
