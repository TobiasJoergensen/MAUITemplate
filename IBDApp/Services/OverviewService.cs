using IBDApp.Models;

namespace IBDApp.Services
{
    public class OverviewService
    {
        public OverviewService() { }

        public ProfileModel GetProfileModel()
        {
            return new ProfileModel(1, "Ryan", "Long term IBD patient with severely progressed damage.", 67);
        }
    }
}
