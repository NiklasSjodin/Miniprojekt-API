using Microsoft.EntityFrameworkCore;
using Miniprojekt_API.Data;
using Miniprojekt_API.Models;

namespace Miniprojekt_API.Handlers
{
    public class DbHelper
    {
        public static Person GetPersonAndInterests(ApplicationContext context, int personId)
        {
            Person person = context.Persons
                .Include(p => p.Interests)
                .Where(p => p.Id == personId)
                .Single();

            return person;
        }

        public static Interest GetInterest(ApplicationContext context, int interestId)
        {
            Interest interest = context.Interests
                .Where(i => i.Id == interestId)
                .Single();

            return interest;
        }

        public static Person GetAllInfoOnPerson(ApplicationContext context, int personId, int interestId)
        {
            Person person = context.Persons
                .Include(p => p.Interests)
                .Where (p => p.Id == personId)
                .Single();

            InterestLink links = context.InterestLinks
                .Include(l => l.Url)
                .Where(l => l.Id == interestId)
                .Single();

            return person;
        }
    }
}
