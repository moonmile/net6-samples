namespace Net6WinForms;

using System.Runtime.InteropServices;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ボタンをクリックしたとき
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        var name = textBox1.Text;
        MessageBox.Show(
            $"こんにちは、{name} さん",
            ".NET6の解説",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int GetWindowTextLength(IntPtr hwnd);

    private void button2_Click(object sender, EventArgs e)
    {
        var hwnd = textBox1.Handle;
        int length = GetWindowTextLength(hwnd);
        string name = new string('\0', length + 1);
        GetWindowText(hwnd, name, name.Length);

        MessageBox.Show(
            $"こんにちは、{name} さん",
            ".NET6の解説(WIN32 API)",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

    }
}
