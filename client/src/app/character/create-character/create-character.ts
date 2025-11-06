import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-character',
  imports: [FormsModule],
  templateUrl: './create-character.html',
  styleUrl: './create-character.css'
})
export class CreateCharacter {
  // Static data for dropdowns
  races = ['Human', 'Elf', 'Dwarf', 'Halfling', 'Dragonborn', 'Gnome', 'Half-Orc', 'Tiefling'];

  classes = ['Barbarian', 'Bard', 'Cleric', 'Druid', 'Fighter', 'Monk', 'Paladin', 'Ranger', 'Rogue', 'Sorcerer', 'Warlock', 'Wizard'];

  subclasses: { [key: string]: string[] } = {
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

  // Form model (for binding later)
  formData: any = {
    name: '',
    race: '',
    background: '',
    religion: '',
    class: '',
    subclass: '',
    size: '',
    alignment: '',
    level: 1
  };

  availableSubclasses: string[] = [];

  onClassChange(event: Event) {
    const selectedClass = (event.target as HTMLSelectElement).value;
    this.availableSubclasses = this.subclasses[selectedClass] || [];
    this.formData.subclass = '';
  }

  submitForm() {
    console.log('Form data:', this.formData);
    // Here you would call your API endpoint:
    // this.characterService.createCharacter(this.formData).subscribe(...)
  }
}
