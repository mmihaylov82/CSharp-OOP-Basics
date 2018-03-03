using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public virtual string FirstName
    {
        get { return firstName; }
        set
        {
            //Should start with a capital letter -> "Expected upper case letter! Argument: firstName"
            //Should be more than 3 symbols -> "Expected length at least 4 symbols! Argument: firstName"
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }
    
    public virtual string LastName
    {
        get { return lastName; }
        set
        {
            //Should start with a capital letter -> "Expected upper case letter! Argument: lastName"
            //Should be more than 2 symbols -> "Expected length at least 3 symbols! Argument: lastName "
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }
            lastName = value;
        }
    }
}

