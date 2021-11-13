import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ParcelComponent } from './Components/parcel/parcel.component';
import { ParcelMachineComponent } from './Components/parcel-machine/parcel-machine.component';

@NgModule({
  declarations: [
    AppComponent,
    ParcelComponent,
    ParcelMachineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
