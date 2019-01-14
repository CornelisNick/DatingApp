/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DropzoneComponent } from './dropzone.component';

describe('DropzoneComponent', () => {
  let component: DropzoneComponent;
  let fixture: ComponentFixture<DropzoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropzoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropzoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
