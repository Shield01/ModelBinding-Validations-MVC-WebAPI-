using Microsoft.AspNetCore.Mvc;
using ModelBinding_Validations_MVC_WebAPI_.Models;
using System;

namespace ModelBinding_Validations_MVC_WebAPI_.Controllers
{
    public class HomeController : Controller
    {
        //Demonstrating the use of Model Binding by catcing the value of bookid in the GetBook argument
        [Route("book/{bookid?}/{isloggedin:bool?}")]

        //Demonstrating the use of FromRoute and FromQuery attributes
        public IActionResult GetBook([FromForm]int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            //Book Id should be provided
            if (bookid.HasValue == false)
            {
                return BadRequest("Book id is not supplied or is empty");
            }

            //Book id should be between 1 and 1000

            if (bookid <= 0)
            {
                return BadRequest("Book id cannot be less than or equal to zero");
            }

            if (bookid > 1000)
            {
                return NotFound("Book id cannot be greater than 1000");
            }

            // Is logged in should be true
            if (isloggedin.HasValue == false)
            {
                return StatusCode(401);
            }

            // All conditions are met, return the book

            return Content($"Viewing content of book whose bookId is {bookid}. Book: {book}", "text/plain");
        }
    }
}
