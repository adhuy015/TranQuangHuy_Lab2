using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranQuangHuy_Lab2.Models;

namespace TranQuangHuy_Lab2.Controllers
{
    public class BooksController : Controller
    {
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string title,string author,string imageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML&CSS", "Author 1", "/Content/Image/1.jpg"));
            books.Add(new Book(2, "HTML&CSS 2", "Author 2", "/Content/Image/2.jpg"));
            books.Add(new Book(3, "HTML&CSS 3", "Author 3", "/Content/Image/3.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook()
        {
            return View();
        }
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML&CSS", "Author 1", "/Content/Image/1.jpg"));
            books.Add(new Book(2, "HTML&CSS 2", "Author 2", "/Content/Image/2.jpg"));
            books.Add(new Book(3, "HTML&CSS 3", "Author 3", "/Content/Image/3.jpg"));
            try
            {
                if (ModelState.IsValid)
                    books.Add(book);
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}