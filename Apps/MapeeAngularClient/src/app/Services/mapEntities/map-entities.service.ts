import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMapEntity } from 'src/app/models/mapEntityModels/iMap-entity.model';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MapEntitiesService {

  private entitiesUrl: string = "http://localhost:50001/MapEntities";
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'multipart/form-data; charset=utf-8',
      'Accept': '*/*'
    })
  };

  constructor(private httpClient: HttpClient) { }

  addMapEntity(entity: IMapEntity): Observable<any> {
    console.log("added entity ", entity.Title);
    return this.httpClient.post<any>(this.entitiesUrl, entity, this.httpOptions).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }

    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
