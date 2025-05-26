using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinding_Validations_MVC_WebAPI_.Models;

namespace ModelBinding_Validations_MVC_WebAPI_.CustomModelBinders
{
    //This class demonstrates the implementation of a Custom Model binder
    public class PersonModelBinder : IModelBinder
    {
        Person person = new Person();
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
            {
                person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            //Email Binding
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            //Phone number binding
            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }

            //Password binding
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }

            //Confirm Password binding
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }

            //Price binding
            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
            {
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(person);

            return Task.CompletedTask;
        }
    }
}
