namespace MauiApi;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private readonly HttpClient _cl = new HttpClient();
    private async void OnWebapiClicked(object sender, EventArgs e)
    {
        // var cl = new HttpClient();
        string url = "https://openccpm.com/redmine/projects.json";
        var response = await _cl.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        var result = System.Text.Json.JsonSerializer.Deserialize<Result>(json);
        // 取得した結果の最初を表示する
        if ( result.projects.Count > 0 )
        {
            var project = result.projects.First();
            textId.Text = project.id.ToString();
            textName.Text = project.name;
            textTag.Text = project.identifier;
        }
    }
}


public class project
{
    public int id { get; set; }
    public string name { get; set; }
    public string identifier { get; set; }
    public string description { get; set; }
}
public class Result
{
    public List<project> projects { get; set; }
    public int total_count { get; set; }
}

