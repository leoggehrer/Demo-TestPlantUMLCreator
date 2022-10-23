
namespace TestPlantUMLCreator
{
    public partial class Course : IdentityEntity
    {
        public string Designation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseType Type { get; set; }

        // Navigation
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
