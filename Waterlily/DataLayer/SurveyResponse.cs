using System.ComponentModel.DataAnnotations.Schema;

namespace Waterlily;

public class SurveyResponse
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public Guid SurveyId { get; set; }

    public string QuestionTitle { get; set; }
    public string QuestionDescription { get; set; }
    public string? Response {get; set;}
}
