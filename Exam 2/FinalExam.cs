using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2
{
    public class FinalExam : Exam
    {
        public int Grade { get; set; }
        public Question[] Questions { get; set; }
        public Answers[] Answers { get; set; }
       
        
        public FinalExam() { }
        public FinalExam( int time, int numberOfQuestions ) : base( time, numberOfQuestions )
        {
        }


        public override void CreateListOfQuestions()
        {
            int  TypeOfQuestion;
            bool Flag;

            Questions = new Question[ NumOfQuestion ];

            for (int i = 0; i < Questions.Length; i++)
            {
                do
                {
                    Console.Write($"Hi Abdekrahman (: , Choose Type Of Question Number (  { i + 1 }  )  :  ( 1 for MCQ  ||  2 for True Or False  )  : ");
                    Flag = int.TryParse(Console.ReadLine(), out TypeOfQuestion);     //False
                }while( !Flag || TypeOfQuestion < 1 || TypeOfQuestion > 2 );


                Console.Clear();


                if ( TypeOfQuestion == 1 )
                {
                    Questions[i] = new MCQ_Q();
                    Questions[i].AddQuestion();
                }

                else if ( TypeOfQuestion == 2 )
                {
                    Questions[i] = new TrueFalse_Q();
                    Questions[i].AddQuestion();
                }
            }
        }


        public override void ShowExam()
        {

            int TotalMark = 0;
            int Grade = 0;
            int  UserAnswer;
           
            bool Flag;


            foreach (var Question in Questions )
            {

                Console.WriteLine( Question );

                

                for (int i = 0; i < Question.AnswerList.Length; i++)
                {
                    Console.WriteLine(Question.AnswerList[i]);
                }


                Console.WriteLine("\n======================\n");




                if ( Question.Header == " MCQ Question ")
                {


                    do
                    {
                        Console.WriteLine("  Enter number of your answer :  ");
                        Flag = int.TryParse(Console.ReadLine(), out UserAnswer);  //False

                    }
                    while
                    ( !Flag || UserAnswer < 1 || UserAnswer > 3 );



                    Question.StudentAnswer.AnswerId = UserAnswer;
                    Question.StudentAnswer.AnswerText = Question.AnswerList[UserAnswer - 1].AnswerText;


                   

                }
                else if (Question.Header == " True or False question ")
                {


                    do
                    {
                        Console.WriteLine(" Enter number of your answer :   ");
                        Flag = int.TryParse(Console.ReadLine(), out UserAnswer);  //False
                    }
                    while 
                    ( !Flag || UserAnswer < 1 || UserAnswer > 2);


                    Question.StudentAnswer.AnswerId = UserAnswer;
                    Question.StudentAnswer.AnswerText = Question.AnswerList[ UserAnswer - 1 ].AnswerText;


                }


                Console.WriteLine("\n==============================\n");
                Console.Clear();


                TotalMark += Question.Mark;

            }


            for (int i = 0; i < Questions.Length; i++)
            {

                if ( Questions[i].RightAnswer.AnswerId == Questions[i].StudentAnswer.AnswerId )
                {
                    Grade += Questions[i].Mark;
                }


                Console.WriteLine($" Question (  { i + 1 } )  :\t { Questions[ i ].Body }");
                Console.WriteLine();

                Console.WriteLine($" Your Answer is  :\t   { Questions[i].StudentAnswer.AnswerText } ");
                Console.WriteLine();

                Console.WriteLine($" The Correct Answer is  :\t {  Questions[i].RightAnswer.AnswerText }");
                Console.WriteLine();
            }

                Console.WriteLine($" Your Grade is  :\t {  Grade  }  From  {  TotalMark  } ");


        }
    }
}
