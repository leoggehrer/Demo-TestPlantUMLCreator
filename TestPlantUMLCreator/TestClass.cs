using System.Diagnostics.Metrics;

namespace TestPlantUMLCreator
{
    public class TestClass
    {
        private static int aPrivateFiled;
        protected static string aProtectedField = string.Empty;
        public static long aPublicfield;
        public static int Counter { get; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
