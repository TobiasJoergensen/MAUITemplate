using IBDApp.ViewModels;

namespace IBDApp.Views;

public partial class Details : ContentPage
{
    private DetailsViewModel _viewModel;
    public VerticalStackLayout GetOverviewOnCompleted { get { return OverviewOnCompleted; } }
    public VerticalStackLayout GetOverviewOnLoading { get { return OverviewOnLoad; } }
    public VerticalStackLayout GetOverviewOnError { get { return OverviewOnError; } }

    public Details()
	{
		InitializeComponent();

        _viewModel = new DetailsViewModel(this);
        //Set the binding context to be our viewmodel
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Init();
    }
}