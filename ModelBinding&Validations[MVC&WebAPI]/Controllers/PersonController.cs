using Microsoft.AspNetCore.Mvc;
using ModelBinding_Validations_MVC_WebAPI_.CustomModelBinders;
using ModelBinding_Validations_MVC_WebAPI_.Models;

namespace ModelBinding_Validations_MVC_WebAPI_.Controllers
{
    public class PersonController : Controller
    {
        [Route("register")]
        public IActionResult Index(
            //Demonstrating the use of Bind keyword
            [Bind(
            nameof(Person.PersonName),
            nameof(Person.Email),
            nameof(Person.Password),
            nameof(Person.ConfirmPassword))] 

            //Demonstrating the use of FromBody keyword
            //Demonstrting the use of Custom model binder 
            //Demonstrating the use of FromHeader keyword
            [FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))] Person person, 
            [FromHeader(Name = "User-Agent")]string userAgent
        )
        {
            if(!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();

                string errors = string.Join(
                    "\n", 
                    ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage)
                );
                return BadRequest(errors);
            }
            return Content($"{person}, {userAgent}");
        }
    }
}
