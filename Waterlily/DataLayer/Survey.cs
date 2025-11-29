namespace Waterlily;

public class Survey
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<SurveyQuestion> Questions { get; set; }
}
