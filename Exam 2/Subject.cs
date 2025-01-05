using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2
{
    public class Subject
    {
        public int SubId { get; set; }
        public string? SubName { get; set; }
        public Exam Exam { get; set; }
        public Question question { get; set; }



        public Subject()
        {
        }
        public Subject(int subId, string subName)
        {
            SubId = subId;
            SubName = subName;
        }



        int TypeOfExam, NumQuestions, TypeOfQuestion;
        int time;
        bool Flag;



        public void CreateExam()
        {
            do
            {
                Console.Write(" Enter The Type Of Exam You Want  ( 1 for practical and 2 for final )  : ");
                Flag = int.TryParse(Console.ReadLine(), out TypeOfExam); //Flase
            }
            while
            (!Flag && TypeOfExam < 1 || TypeOfExam > 2);


            do
            {
                Console.Write(" Enter  Time Of The Exam  : ");
                Flag = int.TryParse(Console.ReadLine(), out time); //Flase
            }
            while
            (!Flag);

            do
            {
                Console.Write(" Enter The Number Of Questions  :  ");
                Flag = int.TryParse(Console.ReadLine(), out NumQuestions); //False
            }
            while
            (!Flag);



            Console.Clear();

            Question[] questions = new Question[NumQuestions];



            if (TypeOfExam == 1)
            {
                Exam = new Practical(time, NumQuestions);
            }
            else
            {
                Exam = new FinalExam(time, NumQuestions);
            }



            Console.Clear();

            Exam.CreateListOfQuestions();
        }
    }
}
