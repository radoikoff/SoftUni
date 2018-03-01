using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Book
{

    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 3)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }


    public string Author
    {
        get { return author; }
        set
        {
            var name = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (name.Length > 1 && char.IsDigit(name[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }


    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    //private bool IsAuthorNameValid(string name)
    //{
    //    var indexOfSpace = name.IndexOf(' ');
    //    var lastName = name.Substring(indexOfSpace).Trim();
    //    if (Char.IsDigit(lastName[0]))
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}

