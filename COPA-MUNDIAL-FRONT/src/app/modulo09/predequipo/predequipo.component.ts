import { Component, OnInit } from '@angular/core';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-predequipo',
  templateUrl: './predequipo.component.html',
  styleUrls: ['./predequipo.component.css']
})
export class PredequipoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    $('#picker').pickdate();
  }

}
