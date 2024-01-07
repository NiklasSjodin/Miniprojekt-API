using Microsoft.EntityFrameworkCore;
using Miniprojekt_API.Data;
using Miniprojekt_API.Handlers;

namespace Miniprojekt_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
            var app = builder.Build();

            app.MapGet("/", () => "Welcome to my first API! Enjoy");

            // Get
            app.MapGet("/persons", PersonHandler.GetPersons); // CHECK Hämta alla personer i systemet
            app.MapGet("/person/{personId}", PersonHandler.GetPersonDetails); // CHECK Hämta ut all information om en specifik person
            app.MapGet("person/{personId}/interests", InterestHandler.GetPersonsInterest); // CHECK Hämta alla intressen till en specifik person
            app.MapGet("person/{personId}/interests/url", InterestHandler.GetPersonAndInterestUrl); // CHECK Hämta alla länkar kopplade till personen

            // Post
            app.MapPost("/person", PersonHandler.AddPerson); // CHECK Lägg till en person i systemet
            app.MapPost("/person/interest", InterestHandler.AddInterest); // CHECK Lägg till ett nytt intresse
            app.MapPost("/person/{personId}/interest/{interestId}", PersonHandler.ConnectPersonToInterest); //CHECK  Koppla en person till ett intresse
            app.MapPost("person/{personId}/interest/{interestId}/url", InterestHandler.AddNewUrl); // CHECK Lägg till en länk för en specifik person och intresse

            app.Run();
        }
    }
}
