using IBDApp.ViewModels;

namespace IBDApp.Views
{
    public partial class Overview : ContentPage
    {
        private OverviewViewModel _viewModel;
        public VerticalStackLayout GetOverviewOnCompleted { get { return OverviewOnCompleted; } }
        public VerticalStackLayout GetOverviewOnLoading { get { return OverviewOnLoad; } }
        public VerticalStackLayout GetOverviewOnError { get { return OverviewOnError; } }

        public Overview()
        {
            InitializeComponent();
            _viewModel = new OverviewViewModel(this);
            //Set the binding context to be our viewmodel
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //When the page is ready to be shown, we start initializing it
            _viewModel.Init();
        }

        private void Error_button(object sender, EventArgs e)
        {
            _viewModel.SetErrorState();
        }

        private void Retry_button(object sender, EventArgs e)
        {
            _viewModel.Init();
        }
    }

}
