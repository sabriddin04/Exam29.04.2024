namespace Domain.Enteties;

public class Course
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Instructor { get; set; }
    public int Credits { get; set; }
    public List<Material>? Materials { get; set; }
    public List<Assignment>? Assignments { get; set; }
}
