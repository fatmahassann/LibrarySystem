using System.Reflection;

namespace LibrarySystem.API.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int PublishedYear { get; set; }
    }


}
