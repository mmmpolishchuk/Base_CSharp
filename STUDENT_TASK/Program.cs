using System;

namespace STUDENT_TASK
{
    class Student
    {
        public int tails;
        public int state;
        public int iq;
        public string name;
        public string faculty;

        public void getInfo()
        {
            Console.WriteLine("All info: \nStudent name is " + name + ", from faculty of " + faculty + "\nThis student " + (state == 1 ? "is drunk" : "isn't drunk") + "," + " with " + tails + " tails" + " and have IQ = " + iq);
        }
        public void analysis()
        {
            if (state == 1 && iq < 70 || state == 1 && tails > 3 || iq < 70 && tails > 3)
            {
                Console.WriteLine("\tTHIS STUDENT MUST BE EXPELLED");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Student student = new Student();
            Random rnd = new Random();

            Console.Write("\tInput student's name:");
            student.name = Console.ReadLine();
            Console.Write("\tInput student's faculty:");
            student.faculty = Console.ReadLine();

            student.tails = rnd.Next(0, 10);
            student.state = rnd.Next(0, 2);
            student.iq = rnd.Next(40, 131);
            //Console.WriteLine(student.tails > 3 ? "have a tails" : "haven't tails");
            //Console.WriteLine(student.state == 1 ? "is drunk" : "isn't drunk");
            //Console.WriteLine("student.iq = " + student.iq);
            student.getInfo();
            student.analysis();
            if (student.state != 1 && student.iq > 70 || student.state != 1 && student.tails < 3 || student.iq > 70 && student.tails < 3)
            {
                Console.WriteLine("\tRerand");
                student.state = rnd.Next(0, 2);
                if (student.state == 0)
                {
                    student.iq = student.iq + 10;
                }
                student.getInfo();

            }
            Console.ReadKey();
        }
    }
}

