namespace MauiMvvm;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        this.Appearing += MainPage_Appearing;
	}

    private void MainPage_Appearing(object sender, EventArgs e)
    {
        _vm = new MainViewModel();
        this.BindingContext = _vm;
    }
    MainViewModel? _vm;
}




