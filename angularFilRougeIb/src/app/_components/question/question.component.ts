import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/_models/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() question : any
  constructor() { }

  ngOnInit(): void {
  }

}
