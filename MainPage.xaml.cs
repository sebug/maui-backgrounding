using maui_backgrounding.ViewModels;

namespace maui_backgrounding;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}

