import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AnyCnameRecord } from 'node:dns';
import { Answer } from 'src/app/_models/answer';
import { Quiz } from 'src/app/_models/quiz';
import { Solution } from 'src/app/_models/solution';
import { AnswerService } from 'src/app/_services/answer.service';
import { ArchivageService } from 'src/app/_services/archivage.service';
import { AuthService } from 'src/app/_services/auth.service';
import { HomeService } from 'src/app/_services/home.service';
import { SharedService } from 'src/app/_services/shared.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-quiz-candidat',
  templateUrl: './quiz-candidat.component.html',
  styleUrls: ['./quiz-candidat.component.css']
})

@Input() 
export class QuizCandidatComponent implements OnInit {

  quiz : Quiz
  listReponses =new Map<number,number>();
  private http : HttpClient
  
constructor(private shared : SharedService,private homeService : HomeService,private answerService : AnswerService,
  private authService : AuthService, private archivageService : ArchivageService ,private route:Router) {}

  ngOnInit(): void 
  {
    this.shared.quiz.subscribe(quiz=>
    {
      if(quiz.idQuizz>0){
        console.log("found by service")
        this.quiz=quiz
      } else {
        this.shared.code.subscribe((code)=>{
          console.log("quiz not found, query by localstored code",code)
          this.homeService.getByCode(code).subscribe((quiz)=>{
            this.quiz=quiz;
          })
        })
      }
      console.log(this.quiz)
    })
  }

  updateReponse(event){
    this.listReponses.set(event[0],event[1])
    console.clear()

    this.quiz.listquestionsolution.forEach(question =>{
      let q = question as any
      console.log([q.idQuestion,this.listReponses.get(q.idQuestion)])
    })
    
    console.log(this.listReponses)
  }


  valider() {
    this.quiz.listquestionsolution.forEach(question =>{
      console.clear
      let q = question as any
      q.solution.forEach(sol => {
        if(sol.idSolution==this.listReponses.get(q.idQuestion)){
          
          this.answerService.postAnswer({"answer":sol.solution,"result":sol.isTrue}as Answer).subscribe(returnAnswer =>{
            this.shared.currentUser.subscribe(user =>{        
              let oi= {"idUser":user.idUser,"answer_idAnswer":returnAnswer.idAnswer,"question_idQuestion":q.idQuestion}    
              console.log(user)
              console.log(oi)
              this.answerService.postUserAnswer(oi).subscribe()
              // this.archivageService.postArchivage(oi)
            })
          })
        }
    this.route.navigate(["validation_quiz_candidat"]);
      })
    })
  }
  
}
