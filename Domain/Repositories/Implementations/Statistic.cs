using Domain.Repositories.Interfaces;
using MudBlazor;

namespace Domain.Repositories.Implementations;

public class Statistic : IStatistic
{
    private List<ChartSeries> Series { get; set; } = null!;
    private List<string> Dates { get; set; } = null!;

    private string[] TrainingDays { get; set; } = null!;

    private static double Average(IEnumerable<double> values)
    {
        var enumerable = values.ToList();
        var sum = enumerable.Sum();
        return sum / enumerable.Count;
    }

    public List<ChartSeries> GenerateChartSeries()
    {
        /*Series = new List<ChartSeries>()
        {
            new ChartSeries()
            {
                Name = "Overall", Data = new double[]
                {
                    Average(new List<double>()
                    {
                        (double)(Activities[0][0].Weight * Activities[0][0].Repetition * Activities[0][0].Set) / 10,
                        (double)(Activities[1][0].Weight * Activities[1][0].Repetition * Activities[1][0].Set) / 10,
                        (double)(Activities[2][0].Weight * Activities[2][0].Repetition * Activities[2][0].Set) / 10,
                    }),
                    Average(new List<double>()
                    {
                        (double)(Activities[0][1].Weight * Activities[0][1].Repetition * Activities[0][1].Set) / 10,
                        (double)(Activities[1][1].Weight * Activities[1][1].Repetition * Activities[1][1].Set) / 10,
                        (double)(Activities[2][1].Weight * Activities[2][1].Repetition * Activities[2][1].Set) / 10,
                    }),
                    Average(new List<double>()
                    {
                        (double)(Activities[0][2].Weight * Activities[0][2].Repetition * Activities[0][2].Set) / 10,
                        (double)(Activities[1][2].Weight * Activities[1][2].Repetition * Activities[1][2].Set) / 10,
                        (double)(Activities[2][2].Weight * Activities[2][2].Repetition * Activities[2][2].Set) / 10,
                    }),
                    Average(new List<double>()
                    {
                        (double)(Activities[0][3].Weight * Activities[0][3].Repetition * Activities[0][3].Set) / 10,
                        (double)(Activities[1][3].Weight * Activities[1][3].Repetition * Activities[1][3].Set) / 10,
                        (double)(Activities[2][3].Weight * Activities[2][3].Repetition * Activities[2][3].Set) / 10,
                    })
                }
            },
            new ChartSeries()
            {
                Name = Activities[0][0].Exercise.Name, Data = new double[]
                {
                    (double)(Activities[0][0].Weight * Activities[0][0].Repetition * Activities[0][0].Set) / 10,
                    (double)(Activities[0][1].Weight * Activities[0][1].Repetition * Activities[0][1].Set) / 10,
                    (double)(Activities[0][2].Weight * Activities[0][2].Repetition * Activities[0][2].Set) / 10,
                    (double)(Activities[0][3].Weight * Activities[0][3].Repetition * Activities[0][3].Set) / 10,
                }
            },
            new ChartSeries()
            {
                Name = Activities[1][0].Exercise.Name, Data = new double[]
                {
                    (double)(Activities[1][0].Weight * Activities[1][0].Repetition * Activities[1][0].Set) / 10,
                    (double)(Activities[1][1].Weight * Activities[1][1].Repetition * Activities[1][1].Set) / 10,
                    (double)(Activities[1][2].Weight * Activities[1][2].Repetition * Activities[1][2].Set) / 10,
                    (double)(Activities[1][3].Weight * Activities[1][3].Repetition * Activities[1][3].Set) / 10,
                }
            },
            new ChartSeries()
            {
                Name = Activities[0][0].Exercise.Name, Data = new double[]
                {
                    (double)(Activities[2][0].Weight * Activities[2][0].Repetition * Activities[2][0].Set) / 10,
                    (double)(Activities[2][1].Weight * Activities[2][1].Repetition * Activities[2][1].Set) / 10,
                    (double)(Activities[2][2].Weight * Activities[2][2].Repetition * Activities[2][2].Set) / 10,
                    (double)(Activities[2][3].Weight * Activities[2][3].Repetition * Activities[2][3].Set) / 10,
                }
            },
        };*/
        return Series;
    }

    public List<string> GetDatesToString()
    {
        return Dates;
    }

    public List<string> GenerateTrainingDays(IActivityRepository activityRepository, int userId)
    {
        activityRepository.GetActivitiesByUser(userId);
        throw new NotImplementedException();
    }
}