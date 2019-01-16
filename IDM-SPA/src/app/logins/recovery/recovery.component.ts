import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-recovery',
  templateUrl: './recovery.component.html',
  styleUrls: ['./recovery.component.css']
})
export class RecoveryComponent implements OnInit {
  RecoveryForm: FormGroup;
  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  send() {

  }

}
