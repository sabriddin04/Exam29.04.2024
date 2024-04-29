namespace Domain.DTOs.AssignmentDto;

public class AddAssignmentDto
{
    public int CourseId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }

}
