using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public IReadOnlyCollection<Product> Products
    {
        get
        {
            return this.products;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public void BuyProduct(Product product)
    {
        this.products.Add(product);
        this.money -= product.Cost;
    }
}

