namespace OOPExam
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Choose exam to run:\n1) Final Exam\n2) Practical Exam\nEnter choice:");
            string examType = Console.ReadLine();


            int time;
            while (true)
            {
                Console.Write("Enter exam time in minutes: ");
                if (int.TryParse(Console.ReadLine(), out time) && time > 0)
                    break;
                Console.WriteLine("Invalid input.");
            }

            int numQuestions;
            while (true)
            {
                Console.Write("Enter number of questions: ");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                    break;
                Console.WriteLine("Invalid input.");
            }

            Exam exam;
            if (examType == "1")
                exam = new FinalExam(time, numQuestions);
            else
                exam = new PracticalExam(time, numQuestions);

            for (int i = 1; i <= numQuestions; i++)
            {
                Console.WriteLine($"\n--- Question {i} ---");
                Console.Write("Enter question type (1 = MCQ, 2 = True/False): ");
                string qType = Console.ReadLine();

                Console.Write("Enter question body: ");
                string body = Console.ReadLine();

                double mark;
                while (true)
                {
                    Console.Write("Enter question mark: ");
                    if (double.TryParse(Console.ReadLine(), out mark) && mark > 0)
                        break;
                    Console.WriteLine("Invalid input.");
                }

                Question question;
                if (qType == "1")
                {
                    question = new MCQQuestion(body, mark);
                    int ansCount;
                    while (true)
                    {
                        Console.Write("How many answers? ");
                        if (int.TryParse(Console.ReadLine(), out ansCount) && ansCount > 1)
                            break;
                        Console.WriteLine("Invalid input.");
                    }
                    for (int a = 1; a <= ansCount; a++)
                    {
                        Console.Write($"Enter text for answer {a}: ");
                        string ansText = Console.ReadLine();
                        question.Answers.Add(new Answer(a, ansText));
                    }

                    int correctId;
                    while (true)
                    {
                        Console.Write("Enter correct answer ID: ");
                        if (int.TryParse(Console.ReadLine(), out correctId) && correctId > 0 && correctId <= ansCount)
                            break;
                        Console.WriteLine("Invalid input.");
                    }
                    question.RightAnswerId = correctId;
                }
                else
                {
                    question = new TrueFalseQuestion(body, mark);
                    while (true)
                    {
                        Console.Write("Enter correct answer (true/false): ");
                        string input = Console.ReadLine().Trim().ToLower();
                        if (input == "true") { question.RightAnswerId = 1; break; }
                        if (input == "false") { question.RightAnswerId = 2; break; }
                        Console.WriteLine("Invalid input.");
                    }
                }

                exam.Questions.Add(question);
            }

            Console.Write("\nEnter subject ID: ");
            int subId;
            while (!int.TryParse(Console.ReadLine(), out subId) || subId <= 0)
                Console.WriteLine("Invalid input.");

            Console.Write("Enter subject name: ");
            string subName = Console.ReadLine();

            Subject subject = new Subject(subId, subName, exam);

            Console.WriteLine();
            Console.WriteLine(subject);
            subject.SubjectExam.ShowExam();

            Console.WriteLine("\nDone. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
