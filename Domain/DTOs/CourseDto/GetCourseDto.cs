namespace Domain.DTOs.CourseDto;

public class GetCourseDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Instructor { get; set; }
    public int Credits { get; set; }
}
