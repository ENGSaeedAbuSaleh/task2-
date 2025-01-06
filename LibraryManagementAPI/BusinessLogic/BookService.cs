using LibraryManagement.DataAccess;
using System.Collections.Generic;

namespace LibraryManagement.BusinessLogic
{
    public class BookService
    {
        private readonly BookRepository _repository;

        public BookService()
        {
            _repository = new BookRepository();
        }

        public List<Book> GetBooks()
        {
            return _repository.GetAllBooks();
        }

        public void AddBook(Book book)
        {
            var books = _repository.GetAllBooks();
            books.Add(book);
            _repository.SaveBooks(books);
        }

        public void UpdateBook(Book updatedBook)
        {
            var books = _repository.GetAllBooks();
            var book = books.Find(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;
                book.ISBN = updatedBook.ISBN;
                book.Quantity = updatedBook.Quantity;
                _repository.SaveBooks(books);
            }
        }

        public void DeleteBook(int id)
        {
            var books = _repository.GetAllBooks();
            books.RemoveAll(b => b.Id == id);
            _repository.SaveBooks(books);
        }
    }
}
