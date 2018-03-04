using System;
using System.Linq;

public class Smartphone : ICallable, ISurfable
{
    public Smartphone()
    {

    }

    public string Call(string number)
    {
        if (IsNumberValid(number))
        {
            return $"Calling... {number}";
        }
        else
        {
            throw new ArgumentException("Invalid number!");
        };
    }

    public bool IsNumberValid(string number)
    {
        if (number.Any(c => (Char.IsLetter(c))))
        {
            return false;
        }
        
        return true;
    }

    public bool IsWebsiteValid(string website)
    {
        if (website.Any(c => (Char.IsDigit(c))))
        {
            return false;
        }

        return true;
    }

    public string Surf(string website)
    {
        if (IsWebsiteValid(website))
        {
            return $"Browsing: {website}!";
        }
        else
        {
            throw new ArgumentException("Invalid URL!");
        };
    }
}

