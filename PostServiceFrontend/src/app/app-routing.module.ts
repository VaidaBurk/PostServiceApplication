import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParcelMachineComponent } from './Components/parcel-machine/parcel-machine.component';
import { ParcelComponent } from './Components/parcel/parcel.component';

const routes: Routes = [
  { path: 'parcelMachines', component: ParcelMachineComponent },
  { path: 'parcels', component: ParcelComponent },
  { path: '', redirectTo: '/parcelMachines', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
