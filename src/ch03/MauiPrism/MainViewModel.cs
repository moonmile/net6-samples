using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Commands;

namespace MauiPrism
{
    internal class MainViewModel : Prism.Mvvm.BindableBase
    {

        private string _message = $"Hello .NET 6 World. on {Device.RuntimePlatform}";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value, nameof(Message));
        }
        public string Username { get; set; }
        public string Password { get; set; }


#if __ANDROID__
    // ANDROIDのみでの動作コード
#endif
#if __IOS__
    // iPhone, iPadでの動作コード
#endif
#if __MACCATALYST__
    // macOSでの動作コード
#endif
#if WINDOWS10_0_17763_0_OR_GREATER
    // Windows 10での動作コード
#endif

        public DelegateCommand LoginClicked { get; private set; }
        public DelegateCommand ResetClicked { get; private set; }  
 
        public MainViewModel()
        {
            this.LoginClicked = new DelegateCommand(
                () =>
                {
                    if (Username == "admin" && Password == "1234")
                    {
                        Message = "ログインできました";
                    }
                    else
                    {
                        Message = "ログインに失敗しました";
                    }
                },
                () => true);

            this.ResetClicked = new DelegateCommand(
                () => {
                    Message = "Hello .NET 6 World.";
                    Username = "";
                    Password = "";
                    this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Username)));
                    this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Password)));
                },
                () => true);
        }
    }
}
