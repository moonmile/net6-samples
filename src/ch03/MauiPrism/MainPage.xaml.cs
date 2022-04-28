namespace MauiPrism;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        this.BindingContext = _vm;
    }
    

    MainViewModel _vm = new MainViewModel();

	private void OnCounterClicked(object sender, EventArgs e)
	{
		// SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

