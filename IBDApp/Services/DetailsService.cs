using IBDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Services
{
    public class DetailsService : IDetailsService
    {
        public List<ProfileModel> GetProfiles()
        {
            List<ProfileModel> profiles = new List<ProfileModel>();
            for (var i = 0; i < 5; i++)
            {
                profiles.Add(new ProfileModel(i, $"User {i}", $"Description of user {i}", i));
            }

            return profiles;
        }
    }
}
