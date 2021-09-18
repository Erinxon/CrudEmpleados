import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ErrorModel } from 'src/app/models/ErrorModel';
import { ErrorService } from 'src/app/services/error.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit, OnDestroy {
  susbcription!: Subscription;
  error!: ErrorModel;

  constructor(private errorService: ErrorService, private ruter: Router) { }


  ngOnInit(): void {
    this.getError();
  }

  ngOnDestroy(): void {
    this.susbcription.unsubscribe();
  }


  getError(): void {
    this.susbcription.add(
    this.errorService.getError().subscribe(e => {
      this.error = e;
    }));
  }

  setError(){
    this.errorService.setError({IsError: false, Message: ''});
    this.ruter.navigate(['/']);
  }

}
