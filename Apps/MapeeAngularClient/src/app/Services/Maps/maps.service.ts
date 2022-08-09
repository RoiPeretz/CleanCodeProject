import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, Subject, throwError } from 'rxjs';
import { IMapModel } from 'src/app/models/mapModel/iMapModel';
import { MapDummyData } from './mapDummyData';

@Injectable({
  providedIn: 'root',
})
export class MapsService {
  private readonly _mapAdded: Subject<IMapModel> = new Subject<IMapModel>();

  private mapRepositoryUrl: string = 'http://localhost:50001/MapRepository';

  constructor(private httpClient: HttpClient) { }
  
  public get mapAdded(): Observable<IMapModel> {
    return this._mapAdded.asObservable();
    
  }

  public getAllMaps(): Observable<Iterable<any>> {
    const arraySource = of(MapDummyData);
    return arraySource;
  }

  public addMap(map: IMapModel): Observable<any> {
    console.log('Uploading map ', map.name);

    this._mapAdded.next(map);

    return this.httpClient
      .post<any>(this.mapRepositoryUrl, map)
      .pipe(catchError(this.handleError));

    // MapDummyData.push(map);
    // this._mapAdded.next(map);
    // const arraySource = of(true);
    // return arraySource;
  }

  public deleteMap(map: IMapModel): Observable<any> {
    return this.httpClient
    .delete<any>(`${this.mapRepositoryUrl}/${map.name}`)
    .pipe(catchError(this.handleError));

    // MapDummyData.splice(MapDummyData.indexOf(map), 1);
    // const arraySource = of(true);
    // return arraySource;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }

    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
}
