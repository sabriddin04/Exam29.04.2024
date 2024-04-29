namespace Domain.DTOs.StudentDto;

public class GetStudentSubmissionCountDto
{
    public int StudentId { get; set; }
    public string? StudentName { get; set; }

    public int Count { get; set; }
}
