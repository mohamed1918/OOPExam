using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numQuestions)
            : base(time, numQuestions)
        { }

        public override void ShowExam()
        {
            Console.WriteLine("=== Practical Exam ===");
            foreach (var q in Questions)
            {
                q.ShowQuestion();

                Console.Write("Your Answer (enter AnswerId): ");
                int userAns;
                var input = Console.ReadLine();
                if (!int.TryParse(input, out userAns))
                    userAns = -1;

                Console.WriteLine("Correct Answer ID: " + q.RightAnswerId);
                Console.WriteLine(userAns == q.RightAnswerId
                    ? " Correct!"
                    : " Wrong!");
                Console.WriteLine();
            }
        }
    }
}
