using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int numberOfLaps;
    private int currentLap;
    public int LengthOfTrack { get; set; }
    private Dictionary<string, Driver> drivers;
    private Dictionary<Driver, string> unfinishedDrivers;
    private Weather weather;
    public Driver Winner { get; private set; }
    public bool IsEndOfRace { get; private set; }

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
        this.weather = Weather.Sunny;
        this.currentLap = 0;
        this.IsEndOfRace = false;
    }

    public int NumberOfLaps
    {
        get { return numberOfLaps; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
            }
            numberOfLaps = value;
        }
    }


    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.NumberOfLaps = lapsNumber;
        this.LengthOfTrack = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var name = commandArgs[1];
            var driver = DriverFactory.CreateDriver(commandArgs);
            drivers.Add(name, driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxCommand = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = drivers[driverName];
        driver.TotalTime += 20;

        switch (boxCommand)
        {
            case "ChangeTyres":
                var args = commandArgs.Skip(2).ToList();
                var tyreToChange = TyreFactory.CreateTyre(args);
                driver.Car.ChangeTyre(tyreToChange);
                break;
            case "Refuel":
                driver.Car.Refuel(double.Parse(commandArgs[2]));
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();
        int laps = int.Parse(commandArgs[0]);

        try
        {
            this.NumberOfLaps -= laps;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        for (int i = 0; i < laps; i++)
        {
            ProcessDriverBeforeOvertaking();
            RemoveOutOfTheRaceDrivers();

            this.currentLap++;
            CheckAndPrintOvertakers(sb);
        }

        //check for end of race and print winner
        if (this.NumberOfLaps == 0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return sb.ToString().Trim();
    }

    private void CheckAndPrintOvertakers(StringBuilder sb)
    {
        //Checking for overtaking opportunities must happen from the slowest (last) driver to the fastest (first). 
        var orderedDrivers = drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

        for (int i = 0; i < orderedDrivers.Count -1; i++)
        {
            var first = orderedDrivers[i];
            var second = orderedDrivers[i + 1];

            var timeFirst = first.TotalTime;
            var timeSecond = second.TotalTime;
            var interval = 2;
            var difference = Math.Abs(timeFirst - timeSecond);
            bool hasCrashed = CheckForSpecialConditions(first, ref interval);

            if (difference <= interval)
            {
                if (hasCrashed)
                {
                    this.unfinishedDrivers.Add(first, "Crashed");

                    RemoveOutOfTheRaceDrivers();
                    continue;
                }

                first.TotalTime -= interval;
                second.TotalTime += interval;

                sb.AppendLine($"{first.Name} has overtaken {second.Name} on lap {this.currentLap}.");
            }
        }
    }

    private bool CheckForSpecialConditions(Driver first, ref int interval)
    {
        bool hasCrashed = false;

        if (first.GetType().Name == "AggressiveDriver"
        && first.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            interval = 3;
            if (this.weather == Weather.Foggy)
            {
                hasCrashed = true;
            }
        }

        if (first.GetType().Name == "EnduranceDriver" && first.Car.Tyre.GetType().Name == "HardTyre")
        {
            interval = 3;
            if (this.weather == Weather.Rainy)
            {
                hasCrashed = true;
            }
        }

        return hasCrashed;
    }

    private void RemoveOutOfTheRaceDrivers()
    {
        foreach (var crashDriver in this.unfinishedDrivers)
        {
            if (drivers.ContainsKey(crashDriver.Key.Name))
            {
                drivers.Remove(crashDriver.Key.Name);
            }
        }
    }

    private void ProcessDriverBeforeOvertaking()
    {
        foreach (var driver in drivers.Values)
        {
            driver.TotalTime += 60 / (this.LengthOfTrack / driver.Speed);
            try
            {
                driver.ReduceFuelAmount(this.LengthOfTrack);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception ex)
            {
                this.unfinishedDrivers.Add(driver, ex.Message);
            }
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        int position = 1;
        sb.AppendLine($"Lap {this.currentLap}/{this.currentLap + this.NumberOfLaps}");

        foreach (var driver in drivers.Values.OrderBy(d => d.TotalTime))
        {

            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }

        var crashesToPrint = unfinishedDrivers.Reverse();

        foreach (var driver in crashesToPrint)
        {
            sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
			position++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherToString = commandArgs[0];
        this.weather = (Weather)Enum.Parse(typeof(Weather),weatherToString);
    }
}

