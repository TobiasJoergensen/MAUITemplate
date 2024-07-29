using IBDApp.Models;

namespace IBDApp.Services
{
    public class OverviewService
    {
        public OverviewService() { }

        public ProfileModel GetProfileModel()
        {
            //Faking a network call here
            Thread.Sleep(4000);

            return new ProfileModel(1, "Ryan", "Long term IBD patient with severely progressed damage.", 67);
        }
    }
}
