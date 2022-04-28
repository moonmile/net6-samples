using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlSample
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlSample : UserControl
    {
        public UserControlSample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            if (username == "admin" && password == "1234")
            {
                this.Message = "ログインできました";
                this.OnLoginSuccess?.Invoke(username);
            }
            else
            {
                this.Message = "ログインに失敗しました";
            }
        }
        /// <summary>
        /// ログインが成功したときにイベント発生
        /// </summary>
        public event Action<string>? OnLoginSuccess;

        /// <summary>
        /// メッセージの状況依存プロパティを定義する
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message",
                typeof(string),
                typeof(UserControlSample),

                new FrameworkPropertyMetadata(
                    "",
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback((o, e) =>
                    {
                        var uc = o as UserControlSample;
                        if ( uc != null )
                        {
                            var data = e.NewValue as string; ;
                            uc.label1.Content = data;
                        }
                    })));
        /// <summary>
        /// Messageプロパティを公開する
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Command状況依存プロパティ
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand), 
                typeof(UserControlSample),
                new UIPropertyMetadata(null));
        /// <summary>
        /// Commandプロパティを公開する
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
    }
}