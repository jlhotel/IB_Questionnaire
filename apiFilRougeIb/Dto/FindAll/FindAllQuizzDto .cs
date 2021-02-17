﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzDto
    {
        public long? IdQuizz { get; set; }
        public string Name { get; set; }
        public long User_idUser { get; set; }
        public long Theme_idTheme { get; set; }
        public string Code { get; set; }
        public string? Comment { get; set; }
        public DateTime? DateFermeture { get; set; }
        public DateTime DateCreation { get; set; }
        public int? Timer { get; set; }

        public FindAllQuizzDto(string name, long user_idUser, long Theme_idTheme, string code, DateTime? dateFermeture, DateTime dateCreation, string? comment, int? timer, long? idQuizz = null)
        {
            this.IdQuizz = idQuizz;
            this.Name = name;
            this.User_idUser = user_idUser;
            this.Theme_idTheme = Theme_idTheme;
            this.Code = code;
            this.DateCreation = dateCreation;
            this.DateFermeture = dateFermeture;
            this.Timer = timer;
        }


    }
}
