using System;

namespace GreatInheriteance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vilken/vilka konstruktorer körs?
            Student myStudent = new Student();
            Student anotherStudent = new Student("Ellen", "Nu", "100101001", 'G');

            // Du vet hur heltal i en array kan sorteras, men...
            int[] numbers = { 21, 5, 7, 213, 3, -1 };
            Array.Sort(numbers);

            foreach (int number in numbers)
            {
                Console.Write("{0,4}", number);
            }
            Console.WriteLine();

            // ...hur sortera referenser till objekt av typen Student?
            Student[] students = new Student[4];

            students[0] = new Student("Mats", "Loock", "1234567890", 'U');
            students[2] = new Student("Ellen", "Nu", "1001010001", 'G');
            students[3] = new Student("Nisse", "Hult", "5603260123", 'U');

            Array.Sort(students);
            foreach (Student student in students)
            {
                // Använder operatorn ? (if-operatorn) för att kunna skriva ut
                // strängen <null> då student refererar till null.
                // ?-operatorn är ett kort sätt att skriva en helt vanlig "if-else"-sats.
                Console.WriteLine(student != null ? student.ToString() : "<null>");
            }
            Console.WriteLine();
        }
    }
}
