using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogu.Model
{

    public class Question {
        public Image Content { get; set; }
        public double Value { get; set; }
    }

    public class Answer
    {
        public Image Content { get; set; }
        public double Value { get; set; }
    }


    public class Form {

        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }

    }



    class Model
    {
    }
}
