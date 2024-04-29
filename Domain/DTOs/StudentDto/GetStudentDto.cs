namespace Domain.DTOs.StudentDto;

public class GetStudentDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
