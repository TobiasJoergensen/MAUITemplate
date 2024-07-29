using IBDApp.Models;
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
    public  class DetailsViewModel : INotifyPropertyChanged
    {
        private Details _detailsView;
        private DetailsStateHandler _detailsStateHandler;
        public List<ProfileModel> ProfileModels { get { return _profileModels; } set { _profileModels = value; } }
        private List<ProfileModel> _profileModels = new List<ProfileModel>();
        public event PropertyChangedEventHandler? PropertyChanged;

        public DetailsViewModel(Details detailsView)
        {
            _detailsView = detailsView;
            _detailsStateHandler = new DetailsStateHandler(detailsView);
        }

        public void Init()
        {
            CreateMockData();
            UpdateUI();
            _detailsStateHandler.setReadyState();
        }

        private void CreateMockData()
        {
            _profileModels.Clear();

            for (var i = 0; i < 5; i++)
            {
                _profileModels.Add(new ProfileModel(i, $"User {i}", $"Description of user {i}", i));
            }

            ProfileModels = _profileModels;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void UpdateUI()
        {
            OnPropertyChanged(nameof(ProfileModels));
        }
    }
}
