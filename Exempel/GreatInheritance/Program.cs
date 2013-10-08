using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatInheriteance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student myStudent = new Student("Ellen", "Nu", "1001011001", 'G');

            //myStudent.FirstName = "Ellen";
            //myStudent.LastName = "Nu";
            //myStudent.CivicRegistrationNumber = "1001011001"; // Meningen med LNU är 37!
            //myStudent.Grade = 'G';

            //Teacher myTeacher = new Teacher();

            //Console.WriteLine(myStudent);

            Student[] students = new Student[4];

            students[0] = new Student("Mats", "Loock", "1234567890", 'U');
            students[2] = new Student("Ellen", "Nu", "1001010001", 'G');
            students[3] = new Student("Nisse", "Hult", "5603260123", 'U');


            int[] numbers = { 21, 5, 7, 213, 3, -1 };
            Array.Sort(numbers);

            foreach (int number in numbers)
            {
                Console.Write("{0,4}", number);
            }
            Console.WriteLine();

            Array.Sort(students);
            foreach (Student student in students)
            {
                Console.WriteLine(student != null ? student.ToString() : "<null>");
            }
            Console.WriteLine();
        }
    }
}
