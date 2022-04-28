namespace WinFormsControlSample.Test;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.Load += Form1_Load;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        this.ucSample.OnLoginSuccess += username =>
        {
            this.groupBox1.Visible = true;
            MessageBox.Show(
                $"{username} さん、おめでとう！",
                ".NET6の解説",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        };
    }
}
