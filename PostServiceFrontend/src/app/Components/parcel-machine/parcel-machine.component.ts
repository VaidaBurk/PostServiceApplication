import { Component, OnInit } from '@angular/core';
import { ParcelMachine } from 'src/app/Models/ParcelMachine';
import { ParcelMachineService } from 'src/app/Services/parcel-machine.service';

@Component({
  selector: 'app-parcel-machine',
  templateUrl: './parcel-machine.component.html',
  styleUrls: ['./parcel-machine.component.css']
})
export class ParcelMachineComponent implements OnInit {

  public parcelMachines: ParcelMachine[] = [];

  public id: number;
  public code: string;
  public city: string;
  public capacity: number;
  public freeSpaces: number;

  public displaySaveButton = true;
  public displayUpdateButton = false;

  public showFormButton = false;
  public hideFormButton = true;

  constructor(
    private _parcelMachineService: ParcelMachineService
  ) { }

  ngOnInit(): void {
    this._parcelMachineService.getAll().subscribe((data) => {
      this.parcelMachines = data;
    })
  }

  public add(): void {
    let newParcelMachine: ParcelMachine = {
      code: this.code,
      city: this.city,
      capacity: this.capacity
    }
    
    this._parcelMachineService.create(newParcelMachine).subscribe((parcelMachine) => {
      this.parcelMachines.push(parcelMachine);
      this.parcelMachines.sort((a, b) => (a.code > b.code) ? 1 : -1);
      this.clearForm();
    });
  }

  public delete(id: number): void {
    this._parcelMachineService.delete(id).subscribe(() => {
      this.parcelMachines = this.parcelMachines.filter((m) => {
        return m.id != id;
      });
    });
  }

  public update(parcelMachine: ParcelMachine): void {
    this.id = parcelMachine.id;
    this.code = parcelMachine.code;
    this.city = parcelMachine.city;
    this.capacity = parcelMachine.capacity;
    this.displaySaveButton = false;
    this.displayUpdateButton = true;
  }

  public saveUpdated(): void {
    let updatedParcelMachine: ParcelMachine = {
      id: this.id,
      code: this.code,
      city: this.city,
      capacity: this.capacity
    }    
    this._parcelMachineService.update(updatedParcelMachine).subscribe((parcelMachine) => {
      this.parcelMachines = this.parcelMachines.map(parcelMachine => parcelMachine.id != updatedParcelMachine.id ? parcelMachine : updatedParcelMachine);
      this.parcelMachines.sort((a, b) => (a.code > b.code) ? 1 : -1);
      this.clearForm();
      this.displayUpdateButton = false;
      this.displaySaveButton = true;
    });
  }

  public clearForm(): void {
    this.code = "";
    this.city = "";
    this.capacity = null;
  }

  public toggleButtons(): void {
    if (this.showFormButton == false){
      this.showFormButton = true;
      this.hideFormButton = false;
    }
    else {
      this.showFormButton = false;
      this.hideFormButton = true;
    }
  }
}
