import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ErrorModel } from 'src/app/models/ErrorModel';
import { ErrorService } from 'src/app/services/error.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {
  error!: ErrorModel;
  constructor(private errorService: ErrorService, private ruter: Router) { }

  ngOnInit(): void {
    this.getError();
  }

  getError(): void {
    this.errorService.getError().subscribe(e => {
      this.error = e;
    })
  }

  setError(){
    this.errorService.setError({IsError: false, Message: ''});
    this.ruter.navigate(['/']);
  }

}
