import { ChangeDetectorRef, Component, ElementRef, HostListener, inject, NgZone } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CharacterService } from '../../shared/services/character.service';
import { finalize, firstValueFrom } from 'rxjs';
import { CreateCharacterDto } from '../../shared/models/create-character-dto';
import { skillsConfig } from '../../shared/models/character.constants';
import { Spell } from '../../shared/models/spell';
import { ToastService } from '../../shared/services/toast.service';
import { groupBy } from 'lodash';

@Component({
  selector: 'app-create-character',
  imports: [FormsModule],
  templateUrl: './create-character.html',
  styleUrl: './create-character.css'
})
export class CreateCharacter {

  constructor(private characterService: CharacterService, private toastService: ToastService) {
    this.formData = this.getDefaultFormData();
  }

  private zone = inject(NgZone);
  private cdr = inject(ChangeDetectorRef);

  portraits: string[] = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
  isPortraitDropdownOpen = false;

  skillsConfig = skillsConfig;

  formData: CreateCharacterDto;

  knownSpells: Spell[] = [];
  spellsByLevel: { [key: number]: any[] } = {}; 
  preparedSpells: Spell[] = [];
  spellsLoading: boolean = false;
  maxPreparedSpells: number = 0;

  // Static data for dropdowns
  races = ['Human', 'Elf', 'Drow Elf', 'Dwarf', 'Halfling', 'Dragonborn', 'Gnome', 'Half-Orc', 'Tiefling'];

  classes = ['Barbarian', 'Bard', 'Cleric', 'Druid', 'Fighter', 'Monk', 'Paladin', 'Ranger', 'Rogue', 'Sorcerer', 'Warlock', 'Wizard', 'Artificer'];

  subclasses: { [key: string]: string[] } = {
    Artificer: ['Alchemist', 'Armorer', 'Artillerist', 'Battle Smith'],
    Barbarian: ['Path of the Berserker', 'Path of the Totem Warrior', 'Path of the Ancestral Guardian', 'Path of the Storm Herald', 'Path of the Zealot'],
    Bard: ['College of Lore', 'College of Valor', 'College of Glamour', 'College of Swords', 'College of Whispers'],
    Cleric: ['Life Domain', 'War Domain', 'Light Domain', 'Knowledge Domain', 'Nature Domain', 'Tempest Domain', 'Trickery Domain', 'Death Domain', 'Forge Domain', 'Grave Domain'],
    Druid: ['Circle of the Land', 'Circle of the Moon', 'Circle of Dreams', 'Circle of the Shepherd', 'Circle of Spores'],
    Fighter: ['Champion', 'Battle Master', 'Eldritch Knight', 'Arcane Archer', 'Cavalier', 'Samurai'],
    Monk: ['Way of the Open Hand', 'Way of Shadow', 'Way of the Four Elements', 'Way of the Drunken Master', 'Way of the Kensei', 'Way of the Sun Soul'],
    Paladin: ['Oath of Devotion', 'Oath of the Ancients', 'Oath of Vengeance', 'Oath of Conquest', 'Oath of Redemption', 'Oathbreaker'],
    Ranger: ['Hunter', 'Beast Master', 'Gloom Stalker', 'Horizon Walker', 'Monster Slayer'],
    Rogue: ['Thief', 'Assassin', 'Arcane Trickster', 'Inquisitive', 'Mastermind', 'Scout', 'Swashbuckler'],
    Sorcerer: ['Draconic Bloodline', 'Wild Magic', 'Divine Soul', 'Shadow Magic', 'Storm Sorcery'],
    Warlock: ['The Fiend', 'The Archfey', 'The Great Old One', 'The Celestial', 'The Hexblade'],
    Wizard: ['Evocation', 'Necromancy', 'Illusion', 'Abjuration', 'Conjuration', 'Divination', 'Enchantment', 'Transmutation', 'War Magic']
  };
  sizes = ['Tiny', 'Small', 'Medium', 'Large', 'Huge', 'Gargantuan'];
  alignments = [
    'Lawful Good', 'Neutral Good', 'Chaotic Good',
    'Lawful Neutral', 'True Neutral', 'Chaotic Neutral',
    'Lawful Evil', 'Neutral Evil', 'Chaotic Evil'
  ];
  levels = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20];

  availableSubclasses: string[] = [];

  savingThrowProficiencies: Record<string, string[]> = {
    Barbarian: ['Strength', 'Constitution'],
    Bard: ['Dexterity', 'Charisma'],
    Cleric: ['Wisdom', 'Charisma'],
    Druid: ['Intelligence', 'Wisdom'],
    Fighter: ['Strength', 'Constitution'],
    Monk: ['Strength', 'Dexterity'],
    Paladin: ['Wisdom', 'Charisma'],
    Ranger: ['Strength', 'Dexterity'],
    Rogue: ['Dexterity', 'Intelligence'],
    Sorcerer: ['Constitution', 'Charisma'],
    Warlock: ['Wisdom', 'Charisma'],
    Wizard: ['Intelligence', 'Wisdom'],
    Artificer: ['Constitution', 'Intelligence']
  };

  skillProficiencies: Record<string, string[]> = {
    Barbarian: ['Animal Handling', 'Athletics', 'Intimidation', 'Nature', 'Perception', 'Survival'],
    Bard: [
      'Acrobatics', 'Animal Handling', 'Arcana', 'Athletics', 'Deception', 'History',
      'Insight', 'Intimidation', 'Investigation', 'Medicine', 'Nature', 'Perception',
      'Performance', 'Persuasion', 'Religion', 'Sleight Of Hand', 'Stealth', 'Survival'
    ],
    Cleric: ['History', 'Insight', 'Medicine', 'Persuasion', 'Religion'],
    Druid: ['Animal Handling', 'Insight', 'Medicine', 'Nature', 'Perception', 'Religion', 'Survival'],
    Fighter: ['Acrobatics', 'Animal Handling', 'Athletics', 'History', 'Insight', 'Intimidation', 'Perception', 'Survival'],
    Monk: ['Acrobatics', 'Athletics', 'History', 'Insight', 'Religion', 'Stealth'],
    Paladin: ['Athletics', 'Insight', 'Intimidation', 'Medicine', 'Persuasion', 'Religion'],
    Ranger: ['Animal Handling', 'Athletics', 'Insight', 'Investigation', 'Nature', 'Perception', 'Stealth', 'Survival'],
    Rogue: ['Acrobatics', 'Athletics', 'Deception', 'Insight', 'Intimidation', 'Investigation', 'Perception', 'Performance', 'Persuasion', 'Sleight Of Hand', 'Stealth'],
    Sorcerer: ['Arcana', 'Deception', 'Insight', 'Intimidation', 'Persuasion', 'Religion'],
    Warlock: ['Arcana', 'Deception', 'History', 'Intimidation', 'Investigation', 'Nature', 'Religion'],
    Wizard: ['Arcana', 'History', 'Insight', 'Investigation', 'Medicine', 'Religion'],
    Artificer: ['Arcana', 'History', 'Investigation', 'Medicine', 'Nature', 'Perception', 'Sleight Of Hand'],
  };


  onClassChange(event: Event) {
    this.spellsLoading = true;
    console.log(this.formData)
    const selectedClass = this.formData.class;
    const spellLevel = Math.floor(Number(this.formData.level)/2) + 1;
    console.log('SpellLevel:' + spellLevel)
    this.availableSubclasses = this.subclasses[selectedClass] || [];
    this.formData.subclass = '';

    Object.keys(this.formData).forEach(key => {
      if (key.endsWith('ApplyProf')) {
        (this.formData as any)[key] = false;
      }
    });

    this.knownSpells = [];
    this.preparedSpells = [];

    this.calculateMaxPreparedSpells(this.formData);

    this.characterService.getKnownSpells(selectedClass, spellLevel)
      .pipe(finalize(() => {
        this.spellsLoading = false;
        this.cdr.detectChanges();
      }))
      .subscribe({
        next: response => {
          this.knownSpells = response;
          this.spellsByLevel = groupBy(this.knownSpells, 'level');
          console.log(this.spellsByLevel);
        },
        error: err => console.log(err)
      })
  }

  isSaveDisabled(selectedClass: string, ability: string) {
    return !this.savingThrowProficiencies[selectedClass].includes(ability);
  }

  isSkillDisabled(selectedClass: string, skill: { key: string, name: string }): boolean {
    const isNotProficient = !this.skillProficiencies[selectedClass].includes(skill.name);
    const disabledByLimit = this.isSkillDisabledFromLimit(skill.key);
    return isNotProficient || disabledByLimit;
  }

  getCheckedSkillsCount(): number {
    const skillKeys = this.skillsConfig.map(skill => skill.key); // only skills
    return skillKeys
      .filter(key => (this.formData as any)[key + 'ApplyProf'])
      .length;
  }

  isSkillDisabledFromLimit(skillKey: string): boolean {
    const checkedCount = this.getCheckedSkillsCount();
    const isChecked = (this.formData as any)[skillKey + 'ApplyProf'];
    // Only disable unchecked skills if 3 are already checked
    return checkedCount >= 3 && !isChecked;
  }

  prepareSpell(spell: Spell, event: Event){
    const input = event.target as HTMLInputElement;
    if (input.checked){
      this.preparedSpells.push(spell);
      this.preparedSpells.sort((a,b) => a.level - b.level);
    }
    else
      this.preparedSpells = this.preparedSpells.filter(s => s.name != spell.name);

    if (this.preparedSpells.length >= this.maxPreparedSpells)
      this.toastService.show('Max prepared spells reached', 'info');
  }

  isDisabledFromMaxPreparedLimit(spell: Spell) {
    const isSelected = this.preparedSpells.some(s => s.id === spell.id);
    
    return this.preparedSpells.length >= this.maxPreparedSpells && !isSelected
  }

  calculateMaxPreparedSpells(charData: CreateCharacterDto) {

    let level = Number(charData.level);

    if (charData.class == 'Cleric' || charData.class == 'Druid'){
      let wisModifier = Math.floor((charData.characterAbilities.wisdom-10)/2);
      this.maxPreparedSpells = level + wisModifier;
      if (this.maxPreparedSpells < 1)
        this.maxPreparedSpells = 1;
    }
    else {
      this.maxPreparedSpells = 0;
    }
  }

  getSpellLevels(): number[] {
    return Object.keys(this.spellsByLevel)
      .map(Number)
      .sort((a, b) => a - b);
  }

  togglePortraitDropdown() {
    this.isPortraitDropdownOpen = !this.isPortraitDropdownOpen;
  }

  selectPortrait(portrait: string) {
    this.formData.imageFrame = portrait;
    this.isPortraitDropdownOpen = false;
  }

  // Optional: Close dropdown when clicking outside
  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;
    if (!target.closest('.relative')) {
      this.isPortraitDropdownOpen = false;
    }
  }

  selectedFile: File | null = null;
  imagePreview: string | null = null;

  // -------------------------------
  // File handling
  // -------------------------------
  async onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files?.length) {
      this.selectedFile = input.files[0];
      this.imagePreview = await this.readFileAsDataURL(this.selectedFile);
    }
  }

  clearFile() {
    this.selectedFile = null;
    this.imagePreview = null;
  }

  private readFileAsDataURL(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => resolve(reader.result as string);
      reader.onerror = error => reject(error);
      reader.readAsDataURL(file);
    });
  }

  // -------------------------------
  // Form submission
  // -------------------------------
  async submitForm() {
    try {
      console.log('Form data:', this.formData);
      this.formData.characterSpells = this.preparedSpells;

      // Step 1: Create character
      const createdCharacter = await firstValueFrom(
        this.characterService.createCharacter(this.formData)
      );

      const characterId = createdCharacter.id;

      // Step 2: Upload avatar if selected
      if (this.selectedFile && characterId) {
        await this.uploadAvatar(characterId, this.selectedFile);
      }

      console.log('Character created successfully with ID:', characterId);
      // TODO: Navigate or show success message
    } catch (error) {
      console.error('Error creating character:', error);
    }
  }

  private async uploadAvatar(characterId: number, file: File) {
    const formData = new FormData();
    formData.append('avatar', file);
    formData.append('characterId', characterId.toString());

    try {
      await firstValueFrom(this.characterService.uploadAvatar(formData));
      console.log('Avatar uploaded successfully');
    } catch (error) {
      console.error('Error uploading avatar:', error);
    }
  }

  getSkillValue(key: string): boolean {
    return (this.formData as any)[key + 'ApplyProf'];
  }

  setSkillValue(key: string, value: boolean, name: string) {
    (this.formData as any)[key + 'ApplyProf'] = value;
  }

  // -------------------------------
  // Default form data
  // -------------------------------
  private getDefaultFormData(): CreateCharacterDto {
    return {
      name: '',
      race: '',
      background: '',
      religion: '',
      class: '',
      subclass: '',
      size: '',
      alignment: '',
      level: 1,
      imageFrame: '',
      hitDice: 1,
      maxHp: 10,
      currentHp: 10,
      speed: 30,
      proficiencyBonus: 2,
      initiative: 0,

      strengthSaveApplyProf: false,
      dexteritySaveApplyProf: false,
      constitutionSaveApplyProf: false,
      intelligenceSaveApplyProf: false,
      wisdomSaveApplyProf: false,
      charismaSaveApplyProf: false,

      acrobaticsApplyProf: false,
      animalHandlingApplyProf: false,
      arcanaApplyProf: false,
      athleticsApplyProf: false,
      deceptionApplyProf: false,
      historyApplyProf: false,
      insightApplyProf: false,
      intimidationApplyProf: false,
      investigationApplyProf: false,
      medicineApplyProf: false,
      natureApplyProf: false,
      perceptionApplyProf: false,
      performanceApplyProf: false,
      persuasionApplyProf: false,
      religionApplyProf: false,
      sleightOfHandApplyProf: false,
      stealthApplyProf: false,
      survivalApplyProf: false,

      characterAbilities: {
        strength: 10,
        dexterity: 10,
        constitution: 10,
        intelligence: 10,
        wisdom: 10,
        charisma: 10,
        strengthModifier: 0,
        dexterityModifier: 0,
        constitutionModifier: 0,
        intelligenceModifier: 0,
        wisdomModifier: 0,
        charismaModifier: 0
      },

      characterSpells: []
    };
  }
}
