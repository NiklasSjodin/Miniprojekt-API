using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miniprojekt_API.Data;
using Miniprojekt_API.Models;
using Miniprojekt_API.Models.DTO;
using Miniprojekt_API.Models.ViewModels;
using System.Net;

namespace Miniprojekt_API.Handlers
{
    public class InterestHandler
    {
        public static IResult GetPersonsInterest(ApplicationContext context, int personId)
        {
            Person person = DbHelper.GetPersonAndInterests(context, personId);

            List<InterestPersonViewModel> personInterest =
                person.Interests
                .Select(i => new InterestPersonViewModel()
                {
                    Title = i.Title,
                    Description = i.Description,
                })
                .ToList();

            return Results.Json(personInterest);
        }

        public static IResult GetPersonAndInterestUrl(ApplicationContext context, int personId)
        {
            Person person = context.Persons
                .Where(p => p.Id == personId)
                .Include(p => p.InterestLinks)
                .SingleOrDefault();

            if (person == null)
            {
                return Results.NotFound("Person not found.");
            }

            List<InterestLinkViewModel> interestUrls = person.InterestLinks
                .Select(il => new InterestLinkViewModel()
                {
                    Url = il.Url,
                })
                .ToList();

            return Results.Json(interestUrls);
        }


        public static IResult AddInterest(ApplicationContext context, InterestDto dto)
        {
            Interest interest = new Interest()
            {
                Title = dto.Title,
                Description = dto.Description,
            };
            context.Interests.Add(interest);
            context.SaveChanges();

            return Results.Ok("Interest succussfully added.");
        }


        public static IResult AddNewUrl(ApplicationContext context, int personId, int interestId, InterestLinkDto dto)
        {
            Person person =
                context.Persons
                .Where(p => p.Id == personId)
                .Single();

            Interest interest =
                context.Interests
                .Where(i => i.Id == interestId)
                .Single();

            InterestLink newInterestLink = new InterestLink()
            {
                Url = dto.Url,
                Person = person,
                Interests = interest
            };

            context.InterestLinks.Add(newInterestLink);
            interest.InterestLinks.Add(newInterestLink);

            context.SaveChanges();
            return Results.Ok("Url successfully added.");
        }
    }
}
