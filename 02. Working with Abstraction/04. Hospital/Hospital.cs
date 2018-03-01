using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> patientsPerDoctor = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();
            
            string input; 

            while ((input = Console.ReadLine()) != "Output")
            {
                ParseInput(patientsPerDoctor, departments, input);
            }
            
            while ((input = Console.ReadLine()) != "End")
            {
                PrintOutput(patientsPerDoctor, departments, input);
            }
        }

        private static void PrintOutput(Dictionary<string, List<string>> patientsPerDoctor, Dictionary<string, List<List<string>>> departments, string input)
        {
            string[] args = input.Split();

            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", patientsPerDoctor[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static void ParseInput(Dictionary<string, List<string>> patientsPerDoctor, Dictionary<string, List<List<string>>> departments, string input)
        {
            string[] inputArgs = input.Split();
            var departament = inputArgs[0];
            var doctorFirstName = inputArgs[1];
            var doctorLastName = inputArgs[2];
            var patientName = inputArgs[3];
            var doctorfullName = doctorFirstName + doctorLastName;

            if (!patientsPerDoctor.ContainsKey(doctorFirstName + doctorLastName))
            {
                patientsPerDoctor[doctorfullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool foundEmptyBed = departments[departament].SelectMany(x => x).Count() < 60;

            if (foundEmptyBed)
            {
                int room = 0;
                patientsPerDoctor[doctorfullName].Add(patientName);
                for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
                {
                    if (departments[departament][currentRoom].Count < 3)
                    {
                        room = currentRoom;
                        break;
                    }
                }
                departments[departament][room].Add(patientName);
            }
        }
    }
}