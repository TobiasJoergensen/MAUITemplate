using IBDApp.ViewModels;

namespace IBDApp.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();
        BindingContext = detailsViewModel;
        detailsViewModel.Init(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}