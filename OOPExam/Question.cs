using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public abstract class Question : ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public int RightAnswerId { get; set; }

        public Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = new List<Answer>();
        }

        public abstract void ShowQuestion();

        public object Clone()
        {
            Question q = (Question)this.MemberwiseClone();
            q.Answers = new List<Answer>();
            foreach (var ans in this.Answers)
                q.Answers.Add((Answer)ans.Clone());
            return q;
        }

        public override string ToString()
        {
            return $"{Header}: {Body} ({Mark} pts)";
        }
    }
}
