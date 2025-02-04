using IBDApp.ViewModels;

namespace IBDApp.Views;

public partial class DetailsPage : ContentPage
{
    private DetailsViewModel _viewModel;
    public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();

        _viewModel = detailsViewModel;
        BindingContext = _viewModel;
        _viewModel.Init(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}