using JsonSubTypes;
using Microsoft.EntityFrameworkCore;
using PollApp.Application;
using PollApp.Application.Models.Poll;
using PollApp.Core.Enum;
using PollApp.DataAccess.Identity;
using PollApp.DataAccess.Persistence;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.Converters.Add(
    JsonSubtypesConverterBuilder
    .Of(typeof(CreateUserAnswerModelAbstract), "questionType")
    .RegisterSubtype(typeof(CreateUserAnswerModelOneOption), QuestionType.OneAnswer)
    .RegisterSubtype(typeof(CreateUserAnswerModelMultipleOptions), QuestionType.MultipleAnswer)
    .SerializeDiscriminatorProperty()
    .Build()
    );
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ContextConnection") ?? throw new InvalidOperationException("Connection string 'ContextConnection' not found.");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddApplication(builder.Environment);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
