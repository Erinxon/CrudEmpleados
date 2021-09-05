import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ErrorService } from '../services/error.service';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ErrorModel } from '../models/ErrorModel';

@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {

  constructor(private errorService: ErrorService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.errorService.setError({ IsError: false, Message: ''});
    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          const errorModel: ErrorModel ={ IsError: true, Message: ''}; 
          if(!error.error.succeeded){
            errorModel.Message = error.error.message;
          }
          if (error.error instanceof ErrorEvent) {
            errorModel.Message = `Ocurrio un error inesperado!`;
          }
          this.errorService.setError(errorModel);
          return throwError(errorModel);
        })
      )
  }
}
