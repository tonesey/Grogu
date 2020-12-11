﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroguCommon
{

    public class Question {
        public Image Content { get; set; }
        public double Value { get; set; }
    }

    public class Answer
    {
        public Image Content { get; set; }
        public double Value { get; set; }
        public bool IsOpen { get; set; }
    }


    public class QuizForm {

        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
        public bool IsOpen { get; set; }
    }



}