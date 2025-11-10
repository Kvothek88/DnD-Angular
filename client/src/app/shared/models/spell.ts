export interface Spell {
  id: number;
  name: string;
  description: string;
  level: number;
  school: string;
  isConcentration: boolean;
  isDuration: boolean;
  isRitual: boolean;
  duration: string;
  range: number;
  castingTime: string;
  classes: string;
}