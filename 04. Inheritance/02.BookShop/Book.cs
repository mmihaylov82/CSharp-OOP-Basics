using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    protected virtual string Author
    {
        get { return author; }
        set
        {
            string[] names = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (names.Length > 1)
            {
                string authorLastName = names[1];
                if (Char.IsDigit(authorLastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }
    
    protected virtual string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }
    
    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().TrimEnd();
    }
}

