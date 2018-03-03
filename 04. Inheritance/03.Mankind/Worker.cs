using System;
using System.Text;


public class Worker : Human
{
    private double weekSalary;
    private double hoursPerDay;

    public Worker(string firstName, string lastName, double salary, double workingHours)
        :base(firstName, lastName)
    {
        this.WeekSalary = salary;
        this.HoursPerDay = workingHours;
    }

    public double WeekSalary
    {
        get { return weekSalary; }
        set
        {
            //Should be more than 10 ->"Expected value mismatch! Argument: weekSalary"
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public double HoursPerDay
    {
        get { return hoursPerDay; }
        set
        {
            //Should be in the range[1..12]  "Expected value mismatch! Argument: workHoursPerDay"
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            hoursPerDay = value;
        }
    }

    public double SalaryPerHour
    {
        get
        {
            return this.weekSalary / ( this.HoursPerDay * 5.0);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.HoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        return sb.ToString().TrimEnd();
    }
}

