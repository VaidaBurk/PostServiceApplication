import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Parcel } from '../Models/Parcel';

@Injectable({
  providedIn: 'root'
})
export class ParcelService {

  constructor(
    private _http: HttpClient
  ) { }

  public getAll(): Observable<Parcel[]>{
    return this._http.get<Parcel[]>('https://localhost:44351/Parcel');
  }

  public delete(id: number): Observable<Parcel> {
    return this._http.delete<Parcel>(`https://localhost:44351/Parcel/${id}`);
  }

  public create(parcel: Parcel): Observable<Parcel> {
    return this._http.post<Parcel>('https://localhost:44351/Parcel', parcel);
  }

  public update(parcel: Parcel): Observable<Parcel> {
    return this._http.put<Parcel>(`https://localhost:44351/Parcel/${parcel.id}`, parcel);
  }

  public filter(id: number): Observable<Parcel[]> {
    return this._http.get<Parcel[]>(`https://localhost:44351/Parcel/Parcelmachine/${id}`);
  }
}
