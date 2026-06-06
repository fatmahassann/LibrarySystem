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




}
