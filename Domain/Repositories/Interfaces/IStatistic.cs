using MudBlazor;

namespace Domain.Repositories.Interfaces;

public interface IStatistic
{
    /// <summary>
    /// Generates the Chart Series with smart selected data from the last entries in Activities.
    /// </summary>
    /// <returns>List of ChartSeries</returns>
    List<ChartSeries> GenerateChartSeries();

    /// <summary>
    /// Return the last dates, which are used in the Series.
    /// </summary>
    /// <returns>List of strings</returns>
    List<string> GetDatesToString();

    /// <summary>
    /// Searches the last training days of the user and predicts the next training day of the user.
    /// </summary>
    /// <returns>List of training days</returns>
    List<string> GenerateTrainingDays(IActivityRepository activityRepository, int userId);
}