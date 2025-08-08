using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numQuestions)
            : base(time, numQuestions)
        { }

        public override void ShowExam()
        {
            Console.WriteLine("=== Final Exam ===");
            double totalMarks = 0, obtainedMarks = 0;
            foreach (var q in Questions)
            {
                q.ShowQuestion();
                Console.Write("Your Answer (enter AnswerId): ");
                int userAns;
                var input = Console.ReadLine();
                if (!int.TryParse(input, out userAns)) userAns = -1;
                totalMarks += q.Mark;
                if (userAns == q.RightAnswerId)
                    obtainedMarks += q.Mark;
            }
            Console.WriteLine($"Grade: {obtainedMarks}/{totalMarks}");
        }
    }
}
