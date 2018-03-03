using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                string facultyNumber = input[2];
                Student student = new Student(firstName, lastName, facultyNumber);

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                firstName = input[0];
                lastName = input[1];
                double salary = double.Parse(input[2]);
                double workingHours = double.Parse(input[3]);
                Worker worker = new Worker(firstName, lastName, salary, workingHours);

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
