using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Prism.Commands;

namespace WpfControlSample.Test
{
internal class MainViewModel : Prism.Mvvm.BindableBase
{
    private Visibility _visible = Visibility.Collapsed;
    public Visibility Visible
    {
        get => _visible;
        set => SetProperty(ref _visible, value, nameof(Visible));
    }

    private string _message = "";
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value, nameof(Message));
    }

    public void OnLoginSuccess(string username)
    {
        this.Visible = Visibility.Visible;
        MessageBox.Show(
            $"おめでとう！",
            ".NET6の解説",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    public DelegateCommand ResetClicked { get; private set; }
    public MainViewModel()
    {
        this.ResetClicked = new DelegateCommand(
            () => {
                this.Message = "Hello .NET 6 World.";
                this.Visible = Visibility.Collapsed;
            }, 
            () => true);
    }

}
}
