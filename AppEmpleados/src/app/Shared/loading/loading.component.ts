import { Component, OnInit } from '@angular/core';
import { ErrorModel } from 'src/app/models/ErrorModel';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {
  isLoanding: boolean = false;
  constructor(private loandingService: LoadingService) { }

  ngOnInit(): void {
    this.loandingService.getLoanding().subscribe((loanding) => {
      this.isLoanding = loanding;
    });
  }

}
