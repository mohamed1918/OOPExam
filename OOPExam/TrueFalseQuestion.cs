using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, double mark)
            : base("True/False Question", body, mark)
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
        }

        public override void ShowQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            foreach (var ans in Answers)
                Console.WriteLine(ans);
        }
    }
}
