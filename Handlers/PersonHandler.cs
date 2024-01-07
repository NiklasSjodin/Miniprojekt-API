using Miniprojekt_API.Data;
using Miniprojekt_API.Models;
using Miniprojekt_API.Models.DTO;
using Miniprojekt_API.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace Miniprojekt_API.Handlers
{
    public class PersonHandler
    {
        public static IResult GetPersons(ApplicationContext context)
        {
            List<PersonViewModel> persons = context.Persons
                .Select(p => new PersonViewModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
            })
            .ToList();
            return Results.Json(persons);
        }

        public static IResult GetPersonDetails(ApplicationContext context, int personId)
        {
            Person person = DbHelper.GetPersonAndInterests(context, personId);

            // Eager load InterestLinks
            context.Entry(person)
                .Collection(p => p.InterestLinks)
                .Load();

            List<InterestPersonViewModel> personInterests = person.Interests
                .Select(i => new InterestPersonViewModel()
                {
                    Title = i.Title,
                    Description = i.Description,
                })
                .ToList();

            List<InterestLinkViewModel> interestUrls = person.InterestLinks
                .Select(il => new InterestLinkViewModel()
                {
                    Url = il.Url,
                })
                .ToList();

            var personDetails = new PersonDetailsViewModel
            {
                PersonInfo = new PersonViewModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                },
                Interests = personInterests,
                InterestUrls = interestUrls,
            };

            return Results.Json(personDetails);
        }



        public static IResult AddPerson(ApplicationContext context, PersonDto personDto)
        {
            Person person = new Person()
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                PhoneNumber = personDto.PhoneNumber,
            };
            context.Persons.Add(person);
            context.SaveChanges();
            return Results.Json(person);
        }

        public static IResult ConnectPersonToInterest(ApplicationContext context, int personId, int interestId)
        {
            Interest interest = DbHelper.GetInterest(context, interestId);
            Person person = DbHelper.GetPersonAndInterests(context, personId);

            person.Interests
                .Add(interest);
            context.SaveChanges();

            return Results.Ok("Interest has been connected.");
        }
    }
}
