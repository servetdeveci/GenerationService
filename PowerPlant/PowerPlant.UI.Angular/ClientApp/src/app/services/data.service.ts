import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const api = 'http://localhost/api';
const powerPlant = 'PowerPlant';
const powerPlantData = 'PowerPlantData';

//const baseUrlPowerPlant = 'http://powerplant-api/api';

@Injectable({
  providedIn: 'root'
})

export class DataService {

  constructor(private http: HttpClient) { }

  getAllPowerPlants(): Observable<any> {
    return this.http.get(`${api}/${powerPlant}`);
  }
  getPowerPlantData(id:string): Observable<any> {
    return this.http.get(`${api}/${powerPlantData}/${id}`);
  }

  getPowerPlantDetail(id:string): Observable<any> {
    return this.http.get(`${api}/${powerPlant}/${id}`);
  }

  create(data): Observable<any> {
    return this.http.post(`${api}/${powerPlant}`, data);
  }

  update(edit:any): Observable<any> {
    return this.http.put(`${api}/${powerPlant}/${edit.id}`,edit);
  }

  delete(id:string): Observable<any> {
    return this.http.delete(`${api}/${powerPlant}/${id}`);
  }
  deletePowerPlantData(id:string): Observable<any> {
    return this.http.delete(`${api}/${powerPlantData}/${id}`);
  }


}
