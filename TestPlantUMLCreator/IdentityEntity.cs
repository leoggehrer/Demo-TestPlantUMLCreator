namespace TestPlantUMLCreator
{
    public partial class IdentityEntity : IIdentifyable
    {
        private static int counter;
        static IdentityEntity()
        {
            counter = 0;
        }
        public IdentityEntity()
        {
            Id = ++counter;
        }
        public int Id { get; private set; }
    }
}
