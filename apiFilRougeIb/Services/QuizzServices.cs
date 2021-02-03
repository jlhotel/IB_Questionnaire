﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class QuizzServices
    {

        private Repositories.QuizzRepository _quizRepository;

        public QuizzServices()
        {
            this._quizRepository = new Repositories.QuizzRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de quiz
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllQuizzDto> GetQuizz()
        {
            List<Models.Quizz> quiz = this._quizRepository.FindAll();
            List<Dto.FindAll.FindAllQuizzDto> quizDto = new List<Dto.FindAll.FindAllQuizzDto>();
            quiz.ForEach(quizz =>
            {
                quizDto.Add(TransformModelToDto(quizz));
            });
            return quizDto;
        }

        /// <summary>
        ///     Retourne un quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllQuizzDto GetQuizz(long id)
        {
            Models.Quizz quiz = this._quizRepository.Find(id);
            Dto.FindAll.FindAllQuizzDto quizDto = TransformModelToDto(quiz);
            return quizDto;
        }

        /// <summary>
        ///     Persister un quiz
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateQuizzDto PostQuizz(Dto.Create.CreateQuizzDto quiz)
        {
            Models.Quizz quizModel = TransformDtoToModel(quiz);
            Models.Quizz quizModelCreated = this._quizRepository.Create(quizModel);
            return TransformModelToAfterCreateDto(quizModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un quiz
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateQuizzDto PutQuizz(long id, Dto.Create.CreateQuizzDto newQuiz)
        {
            Models.Quizz quizModel = TransformDtoToModel(newQuiz);
            Models.Quizz quizModelUpdated = this._quizRepository.Update(id, quizModel);
            return TransformModelToAfterCreateDto(quizModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._quizRepository.Delete(id);
        }
        private Dto.FindAll.FindAllQuizzDto TransformModelToDto(Models.Quizz quiz)
        {
            return new Dto.FindAll.FindAllQuizzDto(quiz.Name, quiz.User_idUser, quiz.IdQuizz);
        }
        private Models.Quizz TransformDtoToModel(Dto.Create.CreateQuizzDto quiz)
        {
            return new Models.Quizz(quiz.Name, quiz.User_idUser);
        }
        private Dto.AfterCreate.AfterCreateQuizzDto TransformModelToAfterCreateDto(Models.Quizz quiz, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateQuizzDto(quiz.Name, quiz.User_idUser, isCreated, quiz.IdQuizz);
        }


    }
}