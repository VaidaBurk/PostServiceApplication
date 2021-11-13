import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ParcelMachine } from '../Models/ParcelMachine'


@Injectable({
  providedIn: 'root'
})
export class ParcelMachineService {

  constructor(
    private _http: HttpClient
  ) { }

  public getAll(): Observable<ParcelMachine[]>{
    return this._http.get<ParcelMachine[]>('https://localhost:44351/ParcelMachine');
  }

  public delete(id: number): Observable<ParcelMachine> {
    return this._http.delete<ParcelMachine>(`https://localhost:44351/ParcelMachine/${id}`);
  }

  public create(parcelMachine: ParcelMachine): Observable<ParcelMachine> {
    return this._http.post<ParcelMachine>('https://localhost:44351/ParcelMachine', parcelMachine);
  }

  public update(parcelMachine: ParcelMachine): Observable<ParcelMachine> {
    return this._http.put<ParcelMachine>(`https://localhost:44351/ParcelMachine/${parcelMachine.id}`, parcelMachine);
  }
}

