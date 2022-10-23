namespace TestPlantUMLCreator
{
    public interface IPerson : IIdentifyable
    {
        string FirstName { get; set; }
        string Fullname { get; }
        string LastName { get; set; }
    }
}