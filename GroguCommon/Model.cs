using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroguCommon
{

    public class Question
    {
        public string ImageContent { get; set; }
        //public double Value { get; set; }
    }

    public class Answer
    {
        public string ImageContent { get; set; }
        public double Value { get; set; }
        //public bool IsOpen { get; set; }
    }

    public class Quiz
    {
        public int TimeLimit { get; set; }
        public bool RandomForms { get; set; }
        public bool RandomQuestions { get; set; }
        public bool AllowBack { get; set; }
        public DateTime StartDateTime { get; set; }
        public List<QuizForm> Forms { get; set; } = new List<QuizForm>();
    }

    public class QuizForm
    {

        public Question Question { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public bool IsOpen { get; set; }
    }


    //stato della verifica a runtime
    //deve essere sempre salvato per riprendere in caso di crash
    public class QuizAnswers
    {
        public List<QuizAnswer> SavedAnswers { get; set; } = new List<QuizAnswer>();
    }

    public class QuizAnswer
    {
        public string QuestionImageContent { get; set; }
        public string AnswerImageContent { get; set; }
    }

}
