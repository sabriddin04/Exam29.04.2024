namespace Domain.Enteties;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public List<Submission>? Submissions { get; set; }
}
