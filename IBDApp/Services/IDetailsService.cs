using IBDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Services
{
    public interface IDetailsService
    {
        public List<ProfileModel> GetProfiles();
    }
}
