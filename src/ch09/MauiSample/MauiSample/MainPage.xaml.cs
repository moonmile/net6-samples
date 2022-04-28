namespace MauiSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";
		SemanticScreenReader.Announce(CounterLabel.Text);

        // クリックした時刻を表示する
        CounterTime.Text = DateTime.Now.ToString("HH:mm:ss");
        SemanticScreenReader.Announce(CounterTime.Text);
    }

    /// <summary>
    /// Clear ボタンでカウンタと時刻表示をクリアする
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClearClicked(object sender, EventArgs e)
    {
        count = 0;
        CounterLabel.Text = $"Current count: {count}";
        SemanticScreenReader.Announce(CounterLabel.Text);

        // クリックした時刻を表示する
        CounterTime.Text = "00:00:00";
        SemanticScreenReader.Announce(CounterTime.Text);
    }
}

