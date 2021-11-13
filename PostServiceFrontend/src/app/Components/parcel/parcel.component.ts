import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/Models/Parcel';
import { ParcelMachine } from 'src/app/Models/ParcelMachine';
import { ParcelMachineService } from 'src/app/Services/parcel-machine.service';
import { ParcelService } from 'src/app/Services/parcel.service';

@Component({
  selector: 'app-parcel',
  templateUrl: './parcel.component.html',
  styleUrls: ['./parcel.component.css']
})
export class ParcelComponent implements OnInit {

  public parcels: Parcel[] = [];
  public parcelMachines: ParcelMachine[] = [];

  public id: number;
  public weight: number;
  public receiver: string;
  public phone: string;
  public info: string;
  public parcelMachineId: number = 0;

  public filterParcelsId: number = 0;

  public displaySaveButton = true;
  public displayUpdateButton = false;
  public showFormButton = false;
  public hideFormButton = true;

  constructor(
    private _parcelService: ParcelService,
    private _parcelMachineService: ParcelMachineService
  ) { }

  ngOnInit(): void {
    this._parcelService.getAll().subscribe((data) => {
      this.parcels = data;
    })
    this._parcelMachineService.getAll().subscribe((data) => {
      this.parcelMachines = data;
    })
  }

  public add(): void {
    let newParcel: Parcel = {
      weight: this.weight,
      receiver: this.receiver,
      phone: this.phone,
      info: this.info,
      parcelMachineId: this.parcelMachineId
    }
    this._parcelService.create(newParcel).subscribe((parcel) => {
      this.parcels.push(parcel);
      this.clearForm();
    },
    (error) => {
      alert(error.error)
    });
  }

  public delete(id: number): void {
    this._parcelService.delete(id).subscribe(() => {
      this.parcels = this.parcels.filter((p) => {
        return p.id != id;
      })
    })
  }

  public update(parcel: Parcel): void {
    this.id = parcel.id;
    this.weight = parcel.weight;
    this.receiver = parcel.receiver;
    this.phone = parcel.phone;
    this.info = parcel.info;
    this.parcelMachineId = parcel.parcelMachineId;
    this.displayUpdateButton = true;
    this.displaySaveButton = false;
  }

  public saveUpdated(): void {
    let updatedParcel = {
      id: this.id,
      weight: this.weight,
      receiver: this.receiver,
      phone: this.phone,
      info: this.info,
      parcelMachineId: this.parcelMachineId
    }   
    this._parcelService.update(updatedParcel).subscribe((parcel) => {
      this.parcels = this.parcels.map(p => p.id != updatedParcel.id ? p : parcel).sort((a, b) => (a.weight > b.weight) ? 1 : -1);
      this.clearForm();
      this.displayUpdateButton = false;
      this.displaySaveButton = true;
    },
    (error) => {
      alert(error.error)
    });
  }

  public filter(filterParcelsId: number): void {
    this._parcelService.filter(filterParcelsId).subscribe((data) => {
      this.parcels = data;
    })
  }

  public clearForm(): void {
    this.weight = null;
    this.receiver = "";
    this.phone = "";
    this.info = "";
    this.parcelMachineId = 0;
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
