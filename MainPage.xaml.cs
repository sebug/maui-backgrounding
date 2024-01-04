using maui_backgrounding.ViewModels;

namespace maui_backgrounding;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		(this.BindingContext as MainViewModel)?.StartFetching();
    }
}

