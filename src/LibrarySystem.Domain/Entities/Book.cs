using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace LibrarySystem.Domain.Entities;

public class Book
{


    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public string Genre { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; } = true;
    public int PublishedYear { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; } = false;

    public Book(string title, string author, string iSBN, string genre, decimal price, int publishedYear)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        ISBN = iSBN;
        Genre = genre;
        Price = price;
        PublishedYear = publishedYear;

        IsAvailable = true;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("title can not be empty!");
        }

        if(price <= 0)
        {
            throw new ArgumentException("Price must be greater than Zero!");
        }


    }

    public void MarkAsBorrowed()
    {
        if(IsAvailable == false)
        {
            throw new InvalidOperationException("الكتاب مستعار بالفعل");
        }

        IsAvailable = false;
 
    }


    public void MarkAsReturned()
    {
        if (IsAvailable == true)
        {
            throw new InvalidOperationException("الكتاب ليس معارا");
        }

        IsAvailable = true;

    }

    public void Update(string title , string author, string genre, decimal price, int publishedYear)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("title can not be empty!");
        }

        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        PublishedYear = publishedYear;

    }

    public void Delete()
    {
        IsDeleted = true;
    }



}
