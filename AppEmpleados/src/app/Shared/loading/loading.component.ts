import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ErrorModel } from 'src/app/models/ErrorModel';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit, OnDestroy {
  susbcription!: Subscription;
  isLoanding: boolean = false;

  constructor(private loandingService: LoadingService) { }

  ngOnInit(): void {
    this.susbcription = this.loandingService.getLoanding().subscribe((loanding) => {
      this.isLoanding = loanding;
    });
  }

  ngOnDestroy(): void {
    this.susbcription.unsubscribe();
  }


}
