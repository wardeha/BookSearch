using Microsoft.AspNetCore.Mvc;

namespace BookSearch.Controllers
{
    using BookSearch.Models;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var books = _bookRepository.SearchBooks(searchTerm);
            return View("Index", books);
        }
    }
}
