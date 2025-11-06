import { Component, HostListener } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CharacterService } from '../../shared/services/character.service';
import { firstValueFrom } from 'rxjs';
import { Character } from '../../shared/models/character';
import { CreateCharacterDto } from '../../shared/models/create-character-dto';
import { skillsConfig } from '../../shared/models/character.constants';

@Component({
  selector: 'app-create-character',
  imports: [FormsModule],
  templateUrl: './create-character.html',
  styleUrl: './create-character.css'
})
export class CreateCharacter {

  constructor(private characterService: CharacterService) {
    this.formData = this.getDefaultFormData();
  }

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

  onClassChange(event: Event) {
    const selectedClass = (event.target as HTMLSelectElement).value;
    this.availableSubclasses = this.subclasses[selectedClass] || [];
    this.formData.subclass = '';
  }

  portraits: string[] = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

  isPortraitDropdownOpen = false;

  skillsConfig = skillsConfig;

  formData: CreateCharacterDto;

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

  setSkillValue(key: string, value: boolean) {
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
      }
    };
  }
}
