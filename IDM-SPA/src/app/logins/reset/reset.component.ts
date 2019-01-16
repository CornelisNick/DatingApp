import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.css']
})
export class ResetComponent implements OnInit {
  ResetForm: FormGroup;
  model: any = {};
  hide: boolean;
  strenght = 0;

  constructor() { }

  ngOnInit() {
    this.hide = true;
  }

  send() {

  }

  changePasswordType() {
    this.hide = !this.hide;
  }

  testStrength() {
    let force = 0;

    const pw = this.model.password;

    /*const lowerLetter = /[a-z]+/.test(pw);
    const upperLetter = /[A-Z]+/.test(pw);
    const numbers = /[0-9]+/.test(pw);
    const symbols = /[$-/:-?{-~!"^_`\[\]]/g.test(pw);*/

    // every charachter + 2 until a max of 10 charachters
    force += (pw.length <= 10) ? 2 * pw.length : 20;

    // tslint:disable-next-line:max-line-length
    const input = (/[a-z]+/.test(pw) ? 10 : 0) + (/[A-Z]+/.test(pw) ? 10 : 0) + (/[0-9]+/.test(pw) ? 10 : 0) + (/[$-/:-?{-~!"^_`\[\]]/g.test(pw) ? 10 : 0);

    force += input;

    // penalty short password min 7
    force += (pw.length < 7) ? 0 : 10;

    // penalty for variety of charachters
    if (force <= 10) { this.strenght = 0; } else
    if (force <= 30) { this.strenght = 1; } else
    if (force <= 40) { this.strenght = 2; } else
    if (force <= 52) { this.strenght = 3; } else { this.strenght = 4; }

     console.log(force);
     console.log(this.strenght);
  }

}
