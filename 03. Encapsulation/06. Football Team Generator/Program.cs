using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (commandArgs[0] == "Team")
                {
                    if (!teams.Any(p => p.Name == commandArgs[1]))
                    {
                        teams.Add(new Team(commandArgs[1]));
                    }
                }
                else if (commandArgs[0] == "Add")
                {
                    //check if Team exists
                    if (!teams.Any(p => p.Name == commandArgs[1]))
                    {
                        throw new ArgumentException($"Team {commandArgs[1]} does not exist.");
                    }
                    string name = commandArgs[2];
                    int endurance = int.Parse(commandArgs[3]);
                    int sprint = int.Parse(commandArgs[4]);
                    int dribble = int.Parse(commandArgs[5]);
                    int passing = int.Parse(commandArgs[6]);
                    int shooting = int.Parse(commandArgs[7]);

                    Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
                    var team = teams.FirstOrDefault(t => t.Name == commandArgs[1]);
                    team.AddPlayer(player);
                }
                else if (commandArgs[0] == "Remove")
                {
                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];
                    var team = teams.FirstOrDefault(t => t.Name == teamName);
                    team.RemovePlayer(playerName);
                }
                else if (commandArgs[0] == "Rating")
                {
                    if (!teams.Any(p => p.Name == commandArgs[1]))
                    {
                        throw new ArgumentException($"Team {commandArgs[1]} does not exist.");
                    }
                    var team = teams.FirstOrDefault(t => t.Name == commandArgs[1]);
                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}

