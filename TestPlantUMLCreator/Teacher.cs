namespace TestPlantUMLCreator
{
    public partial class Teacher : Person
    {
        public string? Title { get; set; }
        public DateTime EmployedOn { get; set; }

        // Navigation
        public List<Course> Courses { get; set; } = new();
    }
}
