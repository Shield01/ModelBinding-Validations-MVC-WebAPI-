using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelBinding_Validations_MVC_WebAPI_.Models;

namespace ModelBinding_Validations_MVC_WebAPI_.CustomModelBinders
{
    //This class demonstrates the use of Model Binder Providers
    public class PersonBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person)) {
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }

            return null;
        }
    }
}
