import { Component, OnInit, ViewChild, ElementRef, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastService } from '../../shared/services/toast.service';

interface DiceInfo {
  name: string;
  src: string;
  value: number;
}

interface Die {
  name: string;
  img: HTMLImageElement;
  x: number;
  y: number;
  w: number;
  h: number;
}

@Component({
  selector: 'app-dice-roller',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="relative w-[213px] bg-amber-100 rounded-3xl left-[10px]">
      <canvas
        #diceCanvas
        (mousemove)="handleMouseMove($event)"
        (mouseleave)="handleMouseLeave()"
        (click)="handleClick($event)"
      ></canvas>

      <div class="absolute bottom-[45px] left-[154px] -translate-x-1/2 flex items-center justify-center gap-1.5">
        <button 
          (click)="decrease()"
          class="bg-yellow-600 text-white text-[15px] font-bold px-2 py-0.5 rounded shadow-md hover:bg-orange-600 transition-colors"
        >
          −
        </button>
        <input 
          type="text" 
          [(ngModel)]="countInput"
          class="w-5 text-center text-[15px] font-semibold border border-gray-300 rounded"
        />
        <button 
          (click)="increase()"
          class="bg-yellow-600 text-white text-[15px] font-bold px-2 py-0.5 rounded shadow-md hover:bg-orange-600 transition-colors"
        >
          +
        </button>
      </div>
    </div>
  `
})
export class DiceRoller implements OnInit, AfterViewInit {
  @ViewChild('diceCanvas', { static: true }) canvasRef!: ElementRef<HTMLCanvasElement>;

  constructor(
    private toastService: ToastService,
    private cdr: ChangeDetectorRef
  ) {}
  
  private canvas!: HTMLCanvasElement;
  private ctx!: CanvasRenderingContext2D;
  
  countInput: number = 1;
  
  private diceImages: DiceInfo[] = [
    { name: "d4", src: "assets/images/d4.png", value: 4 },
    { name: "d6", src: "assets/images/d6.png", value: 6 },
    { name: "d8", src: "assets/images/d8.png", value: 8 },
    { name: "d10", src: "assets/images/d10.png", value: 10 },
    { name: "d12", src: "assets/images/d12.png", value: 12 },
    { name: "d20", src: "assets/images/d20.png", value: 20 },
    { name: "d100", src: "assets/images/d100.png", value: 100 },
  ];
  
  private dice: Die[] = [];
  private xSpacing = 17;
  private ySpacing = 10;
  private dicePerRow = 2;
  private dieSize = 80;
  private hoverGrowth = 5;
  private hoveredDieIndex = -1;
  private loaded = 0;

  ngOnInit(): void {
    this.canvas = this.canvasRef.nativeElement;
    this.ctx = this.canvas.getContext('2d')!;
  }

  ngAfterViewInit(): void {
    this.loadDice();
  }

  private loadDice(): void {
    this.diceImages.forEach((dieInfo, i) => {
      const img = new Image();
      img.src = dieInfo.src;
      img.onload = () => {
        const col = i % this.dicePerRow;
        const row = Math.floor(i / this.dicePerRow);
        const x = col * (this.dieSize + this.xSpacing) + this.xSpacing;
        const y = row * (this.dieSize + this.ySpacing) + this.ySpacing;
        
        this.dice.push({
          name: dieInfo.name,
          img,
          x,
          y,
          w: this.dieSize,
          h: this.dieSize,
        });
        
        this.loaded++;
        if (this.loaded === this.diceImages.length) {
          const totalRows = Math.ceil(this.dice.length / this.dicePerRow);
          this.canvas.width = this.dicePerRow * (this.dieSize + this.xSpacing) + this.xSpacing;
          this.canvas.height = totalRows * (this.dieSize + this.ySpacing) + this.ySpacing;
          this.drawDice();
        }
      };
      img.onerror = () => {
        console.error("Failed to load image:", dieInfo.src);
      };
    });
  }

  private drawDice(): void {
    this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
    this.ctx.imageSmoothingEnabled = true;
    this.ctx.imageSmoothingQuality = 'high';
    
    this.dice.forEach((die, index) => {
      this.ctx.save();
      if (index === this.hoveredDieIndex) {
        this.ctx.shadowColor = 'rgba(255, 215, 0, 0.8)';
        this.ctx.shadowBlur = 15;
        const growAmount = this.hoverGrowth;
        const newWidth = die.w + growAmount;
        const newHeight = die.h + growAmount;
        this.ctx.drawImage(
          die.img,
          die.x - growAmount / 2,
          die.y - growAmount / 2,
          newWidth,
          newHeight
        );
      } else {
        this.ctx.drawImage(die.img, die.x, die.y, die.w, die.h);
      }
      this.ctx.restore();
    });
  }

  private getCanvasCoordinates(e: MouseEvent): { x: number; y: number } {
    const rect = this.canvas.getBoundingClientRect();
    const scaleX = this.canvas.width / rect.width;
    const scaleY = this.canvas.height / rect.height;
    
    return {
      x: (e.clientX - rect.left) * scaleX,
      y: (e.clientY - rect.top) * scaleY
    };
  }

  private isPointInDie(x: number, y: number, die: Die): boolean {
    return (
      x >= die.x &&
      x < die.x + die.w &&
      y >= die.y &&
      y < die.y + die.h
    );
  }

  handleMouseMove(e: MouseEvent): void {
    const coords = this.getCanvasCoordinates(e);
    let foundHover = false;
    
    for (let i = 0; i < this.dice.length; i++) {
      if (this.isPointInDie(coords.x, coords.y, this.dice[i])) {
        if (this.hoveredDieIndex !== i) {
          this.hoveredDieIndex = i;
          this.canvas.style.cursor = "pointer";
          this.drawDice();
        }
        foundHover = true;
        break;
      }
    }
    
    if (!foundHover && this.hoveredDieIndex !== -1) {
      this.hoveredDieIndex = -1;
      this.canvas.style.cursor = "default";
      this.drawDice();
    }
  }

  handleMouseLeave(): void {
    if (this.hoveredDieIndex !== -1) {
      this.hoveredDieIndex = -1;
      this.canvas.style.cursor = "default";
      this.drawDice();
    }
  }

  handleClick(e: MouseEvent): void {
    const coords = this.getCanvasCoordinates(e);

    for (let i = 0; i < this.dice.length; i++) {
      if (this.isPointInDie(coords.x, coords.y, this.dice[i])) {
        const diceValue = this.diceImages.find(x => x.name === this.dice[i].name)!.value;
        const count = this.countInput;

        if (isNaN(count) || count === null || count === 0) {
          this.toastService.show("Invalid data in dice count", 'error');
          return;
        }

        if (diceValue === 100 && count !== 1) {
          this.toastService.show("You can only throw one die for percentage", 'error');
          return;
        }

        if (diceValue === 20 && count > 2) {
          this.toastService.show("You cannot throw more than two d20 dice", 'error');
          return;
        }

        if (diceValue === 20 && count === 2) {
          const choice = prompt("Choose 1 to throw with Advantage or 2 to throw with Disadvantage");
          const roll1 = Math.floor(Math.random() * diceValue) + 1;
          const roll2 = Math.floor(Math.random() * diceValue) + 1;
          
          switch (choice) {
            case "1":
              const maxValue = Math.max(roll1, roll2);
              this.toastService.show(`2d20(Adv) = Max(${roll1},${roll2}) = ${maxValue}`, 'success');
              break;
            case "2":
              const minValue = Math.min(roll1, roll2);
              this.toastService.show(`2d20(Dis) = Min(${roll1},${roll2}) = ${minValue}`, 'success');
              break;
            default:
              this.toastService.show('Wrong choice', 'error');
              break;
          }
          return;
        }

        if (count === 1) {
          const roll = Math.floor(Math.random() * diceValue) + 1;
          this.toastService.show(`${count}d${diceValue} = ${roll}`, 'success');
        } else {
          let result = 0;
          const rolls: number[] = [];
          for (let j = 0; j < count; j++) {
            const roll = Math.floor(Math.random() * diceValue) + 1;
            result += roll;
            rolls.push(roll);
          }
          const rollsString = rolls.join(' + ');
          this.toastService.show(`${count}d${diceValue} = ${rollsString} = ${result}`, 'success');
        }
        return;
      }
    }
  }

  increase(): void {
    this.countInput++;
  }

  decrease(): void {
    this.countInput = Math.max(1, this.countInput - 1);
  }
}
