using IBDApp.Business;
using IBDApp.Models;
using IBDApp.Services;
using IBDApp.State;
using IBDApp.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace IBDApp.ViewModels
{
    public class OverviewViewModel : INotifyPropertyChanged
    {
        private Overview _overviewView;
        private OverviewStateHandler _overviewStateHandler;
        private OverviewService _overviewService;
        private OverviewDomainService _overviewDomainService;
        private ProfileModel ?_profileModel;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _loadingText = "Loading";

        public string Name
        {
            get => (_profileModel?.FullName ?? string.Empty);
        }

        public string Description
        {
            get => (_profileModel?.Description ?? string.Empty);
        }

        public string LoadingText
        {
            get => _loadingText ?? string.Empty;
            set => _loadingText = value;
        }

        public OverviewViewModel(Overview overview) {
            _overviewView = overview;
            _overviewStateHandler = new OverviewStateHandler(overview);
            _overviewService = new OverviewService();
            _overviewDomainService = new OverviewDomainService();
        }

        public void Init()
        {
            LoadData();
        }

        private async void LoadData()
        {
            //We want to run network operations async to avoid a frozen UI
            _overviewStateHandler?.setLoadingState();

            var cancellationToken = new CancellationTokenSource();
            CancellationToken ct = cancellationToken.Token;
            var someTask = Task.Run(() =>
            {
                try
                {
                    ct.ThrowIfCancellationRequested();

                    bool doingStuffOnThread = true;
                    while (doingStuffOnThread)
                    {
                        LoadingTask();

                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }
                    }
                }
                catch (OperationCanceledException) {
                    Debug.WriteLine("Thread stopped. We're done loading.");
                }
                catch (Exception ex) {
                    Debug.WriteLine($"Something bad happened: {ex.Message}");
                }
            }, cancellationToken.Token);
            
            await Task.Run(() =>
            {
                _profileModel = _overviewService.GetProfileModel();
            });

            if (_profileModel != null) {
                //Change business logic
                _profileModel.FullName = _overviewDomainService.FormatNameAndAge(_profileModel.Name, _profileModel.Age);
                _profileModel.Description = _overviewDomainService.FormatDescription(_profileModel.Description);

                //Notify our binding context that the name property has updated
                UpdateUI();
                cancellationToken.Cancel();
                cancellationToken.Dispose();

                //Change the UI to the ready state
                _overviewStateHandler?.setReadyState();
                
                return;
            }
            cancellationToken.Cancel();
            cancellationToken.Dispose();
            _overviewStateHandler?.setErrorState();
        }
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void UpdateUI()
        {
            //Notify all the relevant bindings
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
        }

        public void SetErrorState()
        {
            _overviewStateHandler?.setErrorState();
        }

        private void LoadingTask()
        {
            if (_loadingText != "Loading....")
            {
                _loadingText = $"{LoadingText}.";

            }
            else
            {
                _loadingText = "Loading";
            }
            OnPropertyChanged(nameof(LoadingText));

            Thread.Sleep(500);
        }
    }
}
