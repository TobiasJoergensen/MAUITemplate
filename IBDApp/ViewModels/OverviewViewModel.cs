using IBDApp.Business;
using IBDApp.Models;
using IBDApp.Services;
using IBDApp.State;
using IBDApp.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using IBDApp.Resources.Strings;
using System.ComponentModel.DataAnnotations;
using IBDApp.Validation;
using IBDApp.Validation.Rules;

namespace IBDApp.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        private OverviewPage? _overviewView;
        private OverviewStateHandler? _overviewStateHandler;
        private OverviewService? _overviewService;
        private ProfileModel ?_profileModel;
        public OverviewDomainService OverviewDomainService;

        private Validation<string> _correctName = new Validation<string>();
        private bool _invalidName = false;

        private string _loadingText = "Loading";
        public string Name
        {
            get => (String.Format(Language.WelcomeLabel, (_profileModel?.FullName ?? string.Empty)));
        }

        public string CorrectUsername
        {
            get => _correctName.Value;
            set {
                _correctName.Value = value;
                InvalidName = !_correctName.Validate();
            } 
        }

        public bool InvalidName
        {
            get => _invalidName;
            set { 
                _invalidName = value;
                OnPropertyChanged(nameof(InvalidName));
            }
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

        public OverviewViewModel() {
            OverviewDomainService = new OverviewDomainService();
        }

        public void Init(OverviewPage overview)
        {
            _overviewView = overview;
            _overviewStateHandler = new OverviewStateHandler(overview);
            _overviewService = new OverviewService();

            InitValidations();
            LoadData();
        }

        private void InitValidations() {
            _correctName.Validations.Add(new UsernameRule<string> { ValidationMessage = "Invalid name. Must be 5 char." });
        }

        private async void LoadData()
        {
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
                Thread.Sleep(2000);
            });

            if (_profileModel != null) {
                _profileModel.FullName = OverviewDomainService.FormatNameAndAge(_profileModel.Name, _profileModel.Age);
                _profileModel.Description = OverviewDomainService.FormatDescription(_profileModel.Description);

                UpdateUI();
                cancellationToken.Cancel();
                cancellationToken.Dispose();

                _overviewStateHandler?.setReadyState();
                
                return;
            }
            cancellationToken.Cancel();
            cancellationToken.Dispose();
            _overviewStateHandler?.setErrorState();
        }

        private void UpdateUI()
        {
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
