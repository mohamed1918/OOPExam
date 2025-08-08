using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; } 
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int time, int numQuestions)
        {
            Time = time;
            NumberOfQuestions = numQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();

        public object Clone()
        {
            Exam exam = (Exam)this.MemberwiseClone();
            exam.Questions = new List<Question>();
            foreach (var q in this.Questions)
                exam.Questions.Add((Question)q.Clone());
            return exam;
        }

        public int CompareTo(Exam other)
        {
            return this.NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Time: {Time}min, Questions: {NumberOfQuestions}";
        }
    }
}
