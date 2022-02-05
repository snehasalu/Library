using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooks _book;
        public BookController(IBooks book)
        {
            _book = book;
        }
        #region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetAllBooks()
        {
            return await _book.GetAllBooks();
        }
        #endregion
        #region add book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books books)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _book.AddBook(books);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Books books)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _book.UpdateBook(books);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> Details()
        {
            return await _book.Details();
        }
        
    }
}
