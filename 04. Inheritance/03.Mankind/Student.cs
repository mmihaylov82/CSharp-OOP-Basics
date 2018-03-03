using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber):base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            //A faculty number should be consisted only of digits and letters.
            //Should be in range [5..10] symbols
            if (value.Length < 5 || value.Length > 10 || value.Any(p => !Char.IsLetterOrDigit(p)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.Append($"Faculty number: {this.FacultyNumber}");
        
        return sb.ToString().TrimEnd();
    }
}

