using DataEntities.Entities.Tardis;
using Microsoft.Extensions.Logging;
using PeopleQueryHandler.Models;

namespace PeopleQueryHandler.Console.V1.R1;
public class Console : R0.Console
{
    public Console() { }

    public Console(Action<PeopleQueryHandlerConsoleOptions> action) : base(action) { }

    public override List<PersonHistoryResponseModel> GetPersonHistory(Guid id)
    {
        List<PersonHistoryResponseModel> history = new();
        logger.LogInformation("Getting historical person data for id: {id}", id);

        if (context.PeopleHistory.Any(c => c.PersonId == id))
            foreach (PersonHistory personHistory in context.PeopleHistory.Where(c => c.PersonId == id).OrderByDescending(c => c.ArchiveDate))
                history.Add(new(personHistory));

        if (history.Count > 0)
        {
            logger.LogInformation("Historical person data found!");
            logger.LogDebug("history: {@history}", history);
        }
        else
        {
            logger.LogInformation("No history found");
        }

        return history;
    }
}
