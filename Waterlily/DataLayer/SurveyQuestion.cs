namespace Waterlily;

public class SurveyQuestion
{
    
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
    public string QuestionTitle { get; set; }
    public string QuestionDescription { get; set; }
}
