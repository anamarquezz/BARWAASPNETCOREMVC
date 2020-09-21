using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittlePacktBookstore.Models;
using LittlePacktBookstore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LittlePacktBookstore.Controllers
{
	/// <summary>
	/// Book Controller.
	/// </summary>
    [Produces("application/json")]
	[ApiController]
    [Route("api/[Controller]")]
    public class BookController : Controller
    {
		private readonly IRepository<Book> _bookRepository;
		private readonly ILogger<BookController> _logger;

		// GET: api/Book
		/// <summary>
		/// Constructor for the book controller.
		/// </summary>
		/// <param name="bookRepository">DI injected Book Repository</param>
		/// <param name="logger">DI injected logger</param>
		public BookController(IRepository<Book> bookRepository, ILogger<BookController> logger)
		{
			_bookRepository = bookRepository;
			_logger = logger;
		}

		/// <summary>
		/// This returns all the books.
		/// </summary>
		/// <returns>IEnumerable of books</returns>
		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public ActionResult<IEnumerable<Book>> Get()
		{
			try
			{
				return Ok(_bookRepository.GetAll());
			}
			catch (Exception ex)
			{
				_logger.LogError("Something went wrong:" + ex.Message);
				return NotFound();
			}
		}

		// GET: api/Book/5
		/// <summary>
		/// This method returns one book
		/// </summary>
		/// <param name="id">Id of the book.</param>
		/// <returns>A book.</returns>
		[HttpGet("{id}", Name = "Get")]
		public ActionResult<Book> Get(int id)
		{
			return Ok(_bookRepository.Get(id));
		}

		// POST: api/Book
		/// <summary>
		/// The post method for adding a book
		/// </summary>
		/// <param name="book">Type of Book</param>
		/// <returns>Created on success or appropriate code otherwise.</returns>
		[HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
			try
			{
				if(!ModelState.IsValid)
				{
					_logger.LogError("Invalid model state.");
					return BadRequest();
				}
				else
				{
					_bookRepository.Add(book);
					return Created($"/api/book/{book.Id}", book);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Exception adding new book: " + ex.Message);
				return BadRequest();
			}
        }
        
        // PUT: api/Book/5
		/// <summary>
		/// Put method to edit an existing book.
		/// </summary>
		/// <param name="book">Recieves Book.</param>
		/// <returns>Appropriate Http code.</returns>
        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
			try
			{
				if (!ModelState.IsValid)
				{
					_logger.LogError("Invalid model state.");
					return BadRequest();
				}
				else
				{
					_bookRepository.Edit(book);
					return Ok(book);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Exception adding new book: " + ex.Message);
				return BadRequest();
			}
		}
        
        // DELETE: api/ApiWithActions/5
		/// <summary>
		/// Deletes an existing book.
		/// </summary>
		/// <param name="id">Id of the book to be deleted.</param>
		/// <returns>Appropriate HTTP code.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			try
			{
				var book = _bookRepository.Get(id);
				if (book != null)
				{
					_bookRepository.Delete(book);
					return Ok("Book deleted");
				}
				return BadRequest("Could not delete book.");
			}
			catch (Exception ex)
			{
				_logger.LogError("Exception deleting the book: " + ex.Message);
				return BadRequest();
			}
		}
    }
}
