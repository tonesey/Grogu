using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroguCommon
{

    public class Question {
        public string ImageContent { get; set; }
       //public double Value { get; set; }
    }

    public class Answer
    {
        public string ImageContent { get; set; }
        public double Value { get; set; }
        public bool IsOpen { get; set; }
    }

    public class Quiz
    {
        public List<QuizForm> Forms { get; set; } = new List<QuizForm>();
        public int TimeLimit { get; set; }
        public bool RandomForms { get; set; }
        public bool RandomQuestions { get; set; }
        public bool AllowBack { get; set; }
    }

    public class QuizForm {

        public Question Question { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public bool IsOpen { get; set; }
    }



}
