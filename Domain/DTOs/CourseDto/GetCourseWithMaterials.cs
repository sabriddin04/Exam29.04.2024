using Domain.Enteties;

namespace Domain.DTOs.CourseDto;

public class GetCourseWithMaterials
{
    public Course? Course { get; set; }

    public List<Material>? Materials { get; set; }
}
