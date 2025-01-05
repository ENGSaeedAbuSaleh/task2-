using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryManagement.DataAccess
{
    public class BookRepository
    {
        private const string FilePath = "Data/books.json";

        public List<Book> GetAllBooks()
        {
            if (!File.Exists(FilePath))
                return new List<Book>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Book>>(json);
        }

        public void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(FilePath, json);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
    }
}
