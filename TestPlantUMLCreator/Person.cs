namespace TestPlantUMLCreator
{
    public abstract class Person : IdentityEntity, IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Fullname => $"{LastName} {FirstName}";

        // Methodes
        public static string GetClassName() => typeof(Person).Name;

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
