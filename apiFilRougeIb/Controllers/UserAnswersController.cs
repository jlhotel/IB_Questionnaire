﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFilRougeIb.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiFilRougeIb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserAnswersController : ControllerBase
    {
        // GET api/<UserAnswersController>/5
        //[HttpGet("{id}/Answer}")]
        //public string Get(long idanswer)
        //{
        //    return "value";
        //}
        Services.UserAnswerServices userAnswerServices;

        public UserAnswersController()
        {
            this.userAnswerServices = new Services.UserAnswerServices();
        }
       

        // POST api/<UserAnswersController>
        [HttpGet]
        public List<Models.UserAnswer> Get()
        {
            return userAnswerServices.GetUsers();
        }
        [HttpPost]
        public Dto.FindAll.FindAllUserAnswersDto Post([FromBody] Dto.Create.CreateUserAnswerDto userAnswer)
        {
            return userAnswerServices.Create(userAnswer);
        }


    }
}
