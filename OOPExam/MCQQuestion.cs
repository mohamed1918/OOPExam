using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string body, double mark)
            : base("MCQ Question", body, mark)
        { }

        public override void ShowQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            foreach (var ans in Answers)
                Console.WriteLine(ans);
        }
    }
}
