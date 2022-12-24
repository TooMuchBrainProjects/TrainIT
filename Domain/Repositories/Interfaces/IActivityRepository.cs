using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IActivityRepository : IRepository<Activity>
{
    /// <summary>
    /// Returns you the activity which has the activityId
    /// </summary>
    /// <param name="activityId">Id of the activity you want</param>
    /// <returns>activity with specific activityId</returns>
    Task<Activity> GetActivityById(int activityId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns you all activities from the user given
    /// </summary>
    /// <param name="userId">Id of the user you want to get the activities from</param>
    /// <returns>all activities from the user with the userId</returns>
    Task<List<Activity>> GetActivitiesByUser(int userId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns you all activities from the date given
    /// </summary>
    /// <param name="date">value of date you want to get the activities from</param>
    /// <returns>all activities trained on the given date</returns>
    Task<List<Activity>> GetActivitiesByDate(DateOnly date, CancellationToken ct = default);
    
    /// <summary>
    /// Returns you all activities which are from given user and were trained on the given date (AND-GATE)
    /// </summary>
    /// <param name="userId">Id of the user you want to get the activities from</param>
    /// <param name="date">value of date you want to get the activities from</param>
    /// <returns>all activities where user and date conditions are met</returns>
    Task<List<Activity>> GetActivitiesByUserByDate(int userId, DateOnly date, CancellationToken ct = default);
}