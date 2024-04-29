namespace Domain.DTOs.FeedbackDto;

public class GetFeedbackDto
{
      public int Id { get; set; }
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public string? Text { get; set; }
    public DateTime? FeedbackDate { get; set; }
}
