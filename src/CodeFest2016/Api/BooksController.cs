using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CodeFest2016.Models;
using Microsoft.AspNet.Mvc;

namespace CodeFest2016.Api
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBooksRepository _repo;

        public BooksController(IBooksRepository repo)
        {
            _repo = repo;
        }

        // GET api/books
        [HttpGet]
        public Task<IEnumerable<Book>> Get()
        {
            return _repo.GetBooks();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _repo.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post(Book newBook)
        {
            try
            {
                var book = await _repo.AddBook(newBook);
                var location = new Uri(Url.Link("DefaultApi", new {id = book.Id}));
                return Created(location, book);
            }
            catch (ValidationException ex)
            {
                return HttpBadRequest(ex);
            }
        }

        // PUT api/books/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, Book newBook)
        {
            try
            {
                if (newBook.Id != id)
                {
                    throw new ValidationException("Invalid book ID.");
                }
                var book = await _repo.UpdateBook(newBook);

                return Ok(book);
            }
            catch (ValidationException ex)
            {
                return HttpBadRequest(ex);
            }
        }

        // DELETE api/books/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.DeleteBook(id);
                return new NoContentResult();
            }
            catch (ValidationException ex)
            {
                return HttpBadRequest(ex);
            }
        }
    }
}