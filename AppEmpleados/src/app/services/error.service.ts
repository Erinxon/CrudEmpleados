import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ErrorModel } from '../models/ErrorModel';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {
  private error$ = new BehaviorSubject<ErrorModel>({IsError: false, Message: ''});

  constructor() { }

  setError(error: ErrorModel): void {
    this.error$.next(error);
  }

  getError(): Observable<ErrorModel> {
    return this.error$.asObservable();
  }

}