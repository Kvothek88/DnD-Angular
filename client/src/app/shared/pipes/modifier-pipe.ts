import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'modifier'
})
export class ModifierPipe implements PipeTransform {
  transform(value: number | null | undefined): string {
    if (value == null) return '';
    return value >= 0 ? `+${value}` : `${value}`;
  }
}
