using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    private string name;
    private List<Player> players;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    internal int Rating
    {
        get
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return (int)(players.Average(p => p.Skill));
        }
    }

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        Player player = players.First(p => p.Name == playerName);
        players.Remove(player);
    }
}

