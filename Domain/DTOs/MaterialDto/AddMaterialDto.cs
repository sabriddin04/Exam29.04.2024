namespace Domain.DTOs.MaterialDto;

public class AddMaterialDto
{
    public int CourseId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ContentUrl { get; set; }
}
