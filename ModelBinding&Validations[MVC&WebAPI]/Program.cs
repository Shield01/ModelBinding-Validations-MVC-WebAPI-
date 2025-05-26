using ModelBinding_Validations_MVC_WebAPI_.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // Registering the Model binder provider as a service
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
//Enabling XML Data formatting
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
