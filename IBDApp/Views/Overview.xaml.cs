using IBDApp.ViewModels;

namespace IBDApp.Views
{
    public partial class OverviewPage : ContentPage
    {
        private OverviewViewModel _viewModel;
        public OverviewPage(OverviewViewModel overviewViewModel)
        {
            InitializeComponent();
            _viewModel = overviewViewModel;
            BindingContext = _viewModel;
            _viewModel.Init(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Error_button(object sender, EventArgs e)
        {
            _viewModel.SetErrorState();
        }

        private void Retry_button(object sender, EventArgs e)
        {
            _viewModel.Init(this);
        }
    }

}
