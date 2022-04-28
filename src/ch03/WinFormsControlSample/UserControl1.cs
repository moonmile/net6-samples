namespace WinFormsControlSample;

public partial class UserControl1: UserControl
{
    public UserControl1()
    {
        InitializeComponent();
    }
    /// <summary>
    /// ログインボタンをクリック
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        string username = textUsername.Text;
        string password = textPassword.Text;
        if ( username == "admin" && password == "1234")
        {
            label1.Text = "ログインできました";
            this.OnLoginSuccess?.Invoke(username);
        }
        else
        {
            label1.Text = "ログインに失敗しました";
        }
    }

    /// <summary>
    /// ログインが成功したときにイベント発生
    /// </summary>
    public event Action<string>? OnLoginSuccess;

    /// <summary>
    /// メッセージを取得/設定する
    /// </summary>
    public string Message
    {
        get { return this.label1.Text; }
        set { this.label1.Text = value; }
    }
}

