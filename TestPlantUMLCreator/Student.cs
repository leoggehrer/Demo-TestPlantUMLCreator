namespace TestPlantUMLCreator
{
    public partial class Student : Person
    {
        private List<Course> courses = new();
        public string Number { get; set; } = string.Empty;
        public Course[] Courses => courses.ToArray();

        // Methoden
        public void AddCourse(Course course)
        {
            if (courses.Contains(course) == false)
                courses.Add(course);
        }
        public void RemoveCourse(Course course)
        {
            courses.Remove(course);
        }
    }
}
