using IBDApp.Models;
using IBDApp.Services;
using IBDApp.States;
using IBDApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private DetailsPage? _detailsPage;
        private DetailsStateHandler? _detailsStateHandler;
        private IDetailsService _detailsService;

        public List<ProfileModel> ProfileModels { get { return _profileModels; } set { _profileModels = value; } }
        private List<ProfileModel> _profileModels = new List<ProfileModel>();

        public DetailsViewModel(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        public void Init(DetailsPage details)
        {
            _detailsPage = details;

            CreateMockData();
            UpdateUI();
            _detailsStateHandler = new DetailsStateHandler(details);
            _detailsStateHandler?.setReadyState();
        }

        private void CreateMockData()
        {
            _profileModels.Clear();
            var data = _detailsService.GetProfiles();
            ProfileModels = data;
        }

        private void UpdateUI()
        {
            OnPropertyChanged(nameof(ProfileModels));
        }
    }
}
