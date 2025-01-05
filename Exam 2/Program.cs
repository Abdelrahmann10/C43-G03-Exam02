using System.Diagnostics;

namespace Exam_2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Subject sub = new Subject(1, " C# ");

            sub.CreateExam();

            Console.Clear();

            Console.Write(" Do You Want To Start The Exam ( y | n ) :");


            char c = char.Parse(Console.ReadLine());
            Console.Clear();
            // As the user might enter small letter
            if (c == 'Y' || c == 'y')
            {

                Stopwatch Sw = new Stopwatch();

                Sw.Start();

                sub.Exam.ShowExam();
                Console.WriteLine();

                Console.WriteLine($" Taken Time is :\t {Sw.Elapsed}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(" Thank you Abdelrahman :) ! ");
            }
        }
    }
}
