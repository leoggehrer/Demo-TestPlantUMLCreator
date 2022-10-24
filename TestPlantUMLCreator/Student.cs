namespace TestPlantUMLCreator
{
    public partial class Student : Person
    {
        private List<Course> courses = new();
        public string Number { get; set; } = string.Empty;
        public IEnumerable<Course> Courses => courses.ToArray();

        // Methoden
        public void AddCourse(Course course)
        {
            if (courses.Contains(course) == false)
            {
                courses.Add(course);
                if (course.Students.Contains(this) == false)
                {
                    course.Students.Add(this);
                }
            }
        }
        public void RemoveCourse(Course course)
        {
            if (courses.Contains(course))
            {
                courses.Remove(course);
                if (course.Students.Contains(this))
                {
                    course.Students.Remove(this);
                }
            }
        }
    }
}
