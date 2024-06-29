namespace BookSearch.Models
{
    public class BookRepository
    {
        private List<Book> _books = new List<Book>();
        private int _nextId = 1;

        public void AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return _books.Where(b =>
                b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                b.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
