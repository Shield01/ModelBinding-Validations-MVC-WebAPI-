using Microsoft.AspNetCore.Mvc;

namespace ModelBinding_Validations_MVC_WebAPI_.Models
{
    public class Book
    {
        //Demonstrating the use of the FromQuery attribute, to instruct AspNetCore that the value 
        // of this property should be feteched from the request query during model binding.
        //[FromQuery]
        public int BookId { get; set; }

        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id: {BookId}, Author: {Author}";
        }
    }
}
