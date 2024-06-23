namespace Leads.Tests.Fixture
{

    public class FixtureSingleton
    {
        private static FixtureSingleton _instance;
        public DbFixture DbFixture { get; private set; }
        public ServiceFixture ServiceFixture { get; private set; }

        public FixtureSingleton()
        {
            DbFixture = new DbFixture();
            ServiceFixture = new ServiceFixture();
        }

        public static FixtureSingleton Instance
        {
            get
            {
                return _instance ?? (_instance = new FixtureSingleton());
            }
        }
    }



}
