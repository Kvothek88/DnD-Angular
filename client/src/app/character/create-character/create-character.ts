import { ChangeDetectorRef, Component, HostListener, inject, NgZone } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CharacterService } from '../../shared/services/character.service';
import { finalize, firstValueFrom } from 'rxjs';
import { CreateCharacterDto } from '../../shared/models/create-character-dto';
import { skillsConfig, portraits, races, classes, subclasses, sizes, 
         alignments, levels, savingThrowProficiencies, skillProficiencies, 
         classesCantripsKnown, classesMaxPreparedSpells, classProficiencies,
         proficiencyTypes, proficiencyItems, 
         classSpellcasting} from '../../shared/models/character.constants';
import { Spell } from '../../shared/models/spell';
import { ToastService } from '../../shared/services/toast.service';
import { groupBy } from 'lodash';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-character',
  imports: [FormsModule],
  templateUrl: './create-character.html',
  styleUrl: './create-character.css'
})
export class CreateCharacter {

  constructor(
    private characterService: CharacterService, 
    private toastService: ToastService,
    private router: Router) {
    this.formData = this.getDefaultFormData();
  }

  private zone = inject(NgZone);
  private cdr = inject(ChangeDetectorRef);

  isPortraitDropdownOpen = false;
  formData: CreateCharacterDto;
  knownSpells: Spell[] = [];
  spellsByLevel: { [key: number]: Spell[] } = {};
  spellBookSpellsByLevel: { [key: number]: Spell[] } = {};
  preparedSpells: Spell[] = [];
  cantripsKnown: Spell[] = [];
  spellBookSpells: Spell[] = [];
  spellsLoading: boolean = false;
  maxPreparedSpells: number = 0;
  maxKnownCantrips: number = 0;
  expandedLevels: Record<number, boolean> = {};

  // Static data for dropdowns
  races = races;
  classes = classes;
  subclasses = subclasses;
  sizes = sizes;
  alignments = alignments;
  levels = levels;
  availableSubclasses: string[] = [];
  savingThrowProficiencies = savingThrowProficiencies;
  skillProficiencies = skillProficiencies;
  skillsConfig = skillsConfig;
  portraits = portraits;

  weaponProficiencyTypes: {id: number, name: string}[] = [];
  toolProficiencyTypes: {id: number, name: string}[] = [];
  armorProficiencyTypes: {id: number, name: string}[] = [];
  shieldProficiencyTypes: {id: number, name: string}[] = [];

  weaponProficiencies: {id: number, name: string}[] = [];
  toolProficiencies: {id: number, name: string}[] = [];
  armorProficiencies: {id: number, name: string}[] = [];
  shieldProficiencies: {id: number, name: string}[] = [];


  onClassChange(event: Event) {
    this.spellsLoading = true;
    const selectedClass = this.formData.class;
    const spellLevel = Math.floor(Number(this.formData.level)/2) + 1;
    this.availableSubclasses = this.subclasses[selectedClass] || [];
    this.formData.subclass = '';

    Object.keys(this.formData).forEach(key => {
      if (key.endsWith('ApplyProf')) {
        (this.formData as any)[key] = false;
      }
    });

    this.resetOptions();
    this.calculateCantripsKnown();
    this.calculateMaxPreparedSpells();
    this.calculateClassProficiencies();

    this.characterService.getKnownSpells(selectedClass, spellLevel)
      .pipe(finalize(() => {
        this.spellsLoading = false;
        this.cdr.detectChanges();
      }))
      .subscribe({
        next: response => {
          this.knownSpells = response;
          this.spellsByLevel = groupBy(this.knownSpells, 'level');
          for (let level of this.getSpellLevels()) {
            this.expandedLevels[level] = false;
          }
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
      if (spell.level == 0){
        this.cantripsKnown.push(spell);
        if (this.cantripsKnown.length >= this.maxKnownCantrips)
          this.toastService.show('Max known cantrips reached', 'info');
      }
      else{
        this.preparedSpells.push(spell);
        this.preparedSpells.sort((a,b) => a.level - b.level);
        if (this.preparedSpells.length >= this.maxPreparedSpells)
          this.toastService.show('Max prepared spells reached', 'info');
      }
    }
    else
      if (spell.level == 0)
        this.cantripsKnown = this.cantripsKnown.filter(s => s.name != spell.name);
      else
        this.preparedSpells = this.preparedSpells.filter(s => s.name != spell.name);
  }

  addToSpellbook(spell: Spell, event: Event){
    const input = event.target as HTMLInputElement;
    if (input.checked){
      if (spell.level == 0)
        this.cantripsKnown.push(spell);
      else
        this.spellBookSpells.push(spell);
    }
    else {
      if (spell.level == 0)
        this.cantripsKnown = this.cantripsKnown.filter(s => s.name != spell.name); 
      else {
        this.spellBookSpells = this.spellBookSpells.filter(s => s.name != spell.name); 
        this.preparedSpells = this.preparedSpells.filter(s => s.name != spell.name);
      }
    }

    this.spellBookSpellsByLevel = groupBy(this.spellBookSpells, 'level');
  }

  isDisabledFromMaxPreparedLimit(spell: Spell) {
    const isSelected = this.preparedSpells.some(s => s.id === spell.id);
    return this.preparedSpells.length >= this.maxPreparedSpells && !isSelected
  }

   isDisabledFromMaxCantripsLimit(spell: Spell) {
    const isSelected = this.cantripsKnown.some(s => s.id === spell.id);
    return this.cantripsKnown.length >= this.maxKnownCantrips && !isSelected
  }

  toggleSpellListLevel(level: number) {
    this.expandedLevels[level] = !this.expandedLevels[level];
    Object.keys(this.expandedLevels).forEach(key => {
      const k = Number(key);
      if (k != level){
        this.expandedLevels[k] = false;
      }
    })
  }

  isCantripKnown(spell: Spell): boolean {
    return this.cantripsKnown.some(s => s.id === spell.id);
  }

  isPrepared(spell: Spell): boolean {
    return this.preparedSpells.some(s => s.id === spell.id);
  }

  calculateMaxPreparedSpells(){
    const level = Number(this.formData.level);
    const cls = this.formData.class;

    if (classSpellcasting[cls].isSpellcaster){
      this.maxPreparedSpells = classesMaxPreparedSpells[this.formData.class][level];
    } else {
      this.maxPreparedSpells = 0;
    }
  }

  calculateCantripsKnown(){
    const level = Number(this.formData.level);
    const cls = this.formData.class;

    if (classSpellcasting[cls].hasCantrips){
      this.maxKnownCantrips = classesCantripsKnown[this.formData.class][level];
    } else {
      this.maxKnownCantrips = 0;
    }
  }

  getSpellLevels(): number[] {
    return Object.keys(this.spellsByLevel)
      .map(Number)
      .sort((a, b) => a - b);
  }

  calculateClassProficiencies(){
    classProficiencies[this.formData.class]['Weapon'].forEach(item => {
      let dict = proficiencyTypes.find(t => t.name == item);
      let dictItem: any = null;
      if (dict == null)
        dictItem = proficiencyItems.find(t => t.name == item);
      if (dict != null && !this.weaponProficiencyTypes.some(w => w.id == dict.id)) 
        this.weaponProficiencyTypes.push(dict);
      else if (dictItem != null && !this.weaponProficiencies.some(w => w.id == dictItem.id))
        this.weaponProficiencies.push(dictItem);
    })

    classProficiencies[this.formData.class]['Tools'].forEach(item => {
      let dict = proficiencyTypes.find(t => t.name == item);
      let dictItem: any = null;
      if (dict == null)
        dictItem = proficiencyItems.find(t => t.name == item);
      if (dict != null && !this.toolProficiencyTypes.some(w => w.id == dict.id)) 
        this.toolProficiencyTypes.push(dict);
      else if (dictItem != null && !this.toolProficiencies.some(w => w.id == dictItem.id))
        this.toolProficiencies.push(dictItem);
    })

    classProficiencies[this.formData.class]['Armor'].forEach(item => {
      let dict = proficiencyTypes.find(t => t.name == item);
      let dictItem: any = null;
      if (dict == null)
        dictItem = proficiencyItems.find(t => t.name == item);
      if (dict != null && !this.armorProficiencyTypes.some(w => w.id == dict.id)) 
        this.armorProficiencyTypes.push(dict);
      else if (dictItem != null && !this.armorProficiencies.some(w => w.id == dictItem.id))
        this.armorProficiencies.push(dictItem);
    })

    classProficiencies[this.formData.class]['Shield'].forEach(item => {
      let dict = proficiencyTypes.find(t => t.name == item);
      let dictItem: any = null;
      if (dict == null)
        dictItem = proficiencyItems.find(t => t.name == item);
      if (dict != null && !this.shieldProficiencyTypes.some(w => w.id == dict.id)) 
        this.shieldProficiencyTypes.push(dict);
      else if (dictItem != null && !this.shieldProficiencies.some(w => w.id == dictItem.id))
        this.shieldProficiencies.push(dictItem);
    })
  }

  resetOptions() {
    this.knownSpells = [];
    this.preparedSpells = [];
    this.cantripsKnown = [];
    this.spellBookSpells = [];
    this.spellsByLevel = {};
    this.spellBookSpellsByLevel = {};

    this.weaponProficiencyTypes = [];
    this.toolProficiencyTypes = [];
    this.armorProficiencyTypes = [];
    this.shieldProficiencyTypes = [];

    this.weaponProficiencies = [];
    this.toolProficiencies = [];
    this.armorProficiencies = [];
    this.shieldProficiencies = [];
  }

  togglePortraitDropdown() {
    this.isPortraitDropdownOpen = !this.isPortraitDropdownOpen;
  }

  selectPortrait(portrait: string) {
    this.formData.imageFrame = portrait;
    this.isPortraitDropdownOpen = false;
  }

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
      this.formData.characterPreparedSpells = [
        ...this.cantripsKnown,
        ...this.preparedSpells
      ];

      if (this.formData.class == 'Wizard'){
        this.formData.spellbook = {
          spellbookSpells: this.spellBookSpells.map(s => ({
            spellId: s.id
          }))
        };
      }

      console.log('Form data:', this.formData);

      const createdCharacter = await firstValueFrom(
        this.characterService.createCharacter(this.formData)
      );

      const characterId = createdCharacter.id;

      if (this.selectedFile && characterId) {
        await this.uploadAvatar(characterId, this.selectedFile);
      }

      this.toastService.show('Character created successfully', 'success');
      this.router.navigate(['/characters']);
    } catch (error) {
      this.toastService.show('Error creating character', 'error');
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

      characterPreparedSpells: [],
      characterProficiencies: []
    };
  }
}
