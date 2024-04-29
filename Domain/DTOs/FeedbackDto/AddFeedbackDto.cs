namespace Domain.DTOs.FeedbackDto;

public class AddFeedbackDto
{
     public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public string? Text { get; set; }
    public DateTime? FeedbackDate { get; set; }

}
