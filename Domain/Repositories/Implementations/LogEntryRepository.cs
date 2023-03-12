using Model.Entities.Log;

namespace Domain.Repositories.Implementations;

public class LogEntryRepository : ARepository<LogEntry>, ILogEntryRepository
{
    public LogEntryRepository(TrainITDbContext context) : base(context)
    {
    }
    
    
}