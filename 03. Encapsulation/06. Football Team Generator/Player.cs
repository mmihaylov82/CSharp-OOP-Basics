using System;
using System.Collections.Generic;
using System.Text;

class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    private const int MIN_STAT = 0;
    private const int MAX_STAT = 100;

    internal string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    
    private int Endurance
    {
        get { return endurance; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Endurance should be between {MIN_STAT} and {MAX_STAT}.");
            }
            endurance = value;
        }
    }

    private int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Sprint should be between {MIN_STAT} and {MAX_STAT}.");
            }
            sprint = value;
        }
    }
    
    private int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Dribble should be between {MIN_STAT} and {MAX_STAT}.");
            }
            dribble = value;
        }
    }

    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Passing should be between {MIN_STAT} and {MAX_STAT}.");
            }
            passing = value;
        }
    }

    private int Shooting
    {
        get { return shooting; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Shooting should be between {MIN_STAT} and {MAX_STAT}.");
            }
            shooting = value;
        }
    }
    
    internal int Skill
    {
        get
        {
            return (int)Math.Round((this.Endurance + this.Dribble + this.Sprint + this.Passing + this.Shooting) / 5.0); ;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

}

